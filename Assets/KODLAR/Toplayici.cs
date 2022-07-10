using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Toplayici : MonoBehaviour
{
    public int MoneyCount;
    public TextMeshProUGUI MoneyText;

    [SerializeField] private float Moneypos;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Money")
        {
            col.transform.DOJump(transform.position + new Vector3(0,0,Moneypos), 2, 1, 0.15f).OnComplete(() =>
            {
                col.transform.SetParent(transform);
                col.transform.localPosition = new Vector3(0, 0, Moneypos);
                col.transform.localRotation = Quaternion.identity;
                col.tag = "Untagged";
                MoneyCount += 100;
                if (MoneyCount > 0)
                {
                    Moneypos = (float)MoneyCount / 500;
                }
            }
            );
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Money")
        {
            if (MoneyCount == 0)
            {
                Moneypos = 0;
            }
        }
    }

    private void Update()
    {
        MoneyText.text = "Money = " + MoneyCount.ToString("N0") + " $";
    }
}
