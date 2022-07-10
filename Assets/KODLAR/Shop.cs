using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Shop : MonoBehaviour
{
    public Image Bar;
    public Toplayici player;
    public Transform Uretici;
    public GameObject _Bar;

    public TextMeshProUGUI Fiyat_Text;
    [Range(100,300000)]
    public int Fiyat;

    public TextMeshProUGUI Alinan_Text;
    public int Alinan;

    private BoxCollider _collider;

    private void Awake()
    {
        Fiyat_Text.text = "/ " + Fiyat.ToString("N0") + "$";
        _collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerStay(Collider col)
    {
        if(col.tag == "Player")
        {
            if (col.transform.childCount == 0) return;
            var child = col.transform.GetChild(col.transform.childCount - 1).gameObject;

            if (player.MoneyCount > 0 && Bar.fillAmount < 1)
            {
                child.transform.DOJump(transform.position, 1.5f, 2, 0.15f).OnComplete(() =>
                {
                    if (player.MoneyCount == player.transform.childCount * 100)
                    {
                        player.MoneyCount -= 100;
                        Alinan += 100;
                    }
                    Destroy(child.gameObject, 0.15f);
                    child.transform.SetParent(transform);
                    Bar.fillAmount = Alinan / (float)Fiyat;
                    if (player.MoneyCount < 0)
                    {
                        player.MoneyCount = 0;
                    }
                }

);
            }
        }
        
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            if (col.transform.childCount == 0 && player.MoneyCount > 0)
            {
                Alinan += player.MoneyCount;
                player.MoneyCount = 0;
                Bar.fillAmount = Alinan / (float)Fiyat;
            }
        }
    }

    private void Update()
    {
        Alinan_Text.text = "$" + Alinan.ToString("N0");
        if (Bar.fillAmount >= 1)
        {
            _collider.enabled = false;
            _Bar.SetActive(false);
            Uretici.gameObject.SetActive(true);
        }
    }
}
