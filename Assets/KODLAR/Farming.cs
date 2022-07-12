using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Farming : MonoBehaviour
{

    public List<GameObject> Seedlings;
    public List<GameObject> Carrots;
    public List<GameObject> Virgos;
    private bool Growing;

    private Player playerscript;
    private void Awake()
    {
        playerscript = GameObject.FindWithTag("Player").GetComponent<Player>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Seedlings.Add(transform.GetChild(i).GetChild(1).gameObject);
            Carrots.Add(transform.GetChild(i).GetChild(2).gameObject);
            Virgos.Add(transform.GetChild(i).GetChild(0).gameObject);

            if (i == transform.childCount - 1) break;
        }
    }
    void Start()
    {

    }
    private void Update()
    {
        playerscript._EkmeTusu.onClick.AddListener(() => Farmer());
    }


    private void OnTriggerStay(Collider col)
    {

        if (col.CompareTag("Player") && !Growing)
        {
            playerscript._EkmeTusu.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (playerscript._EkmeTusu.gameObject.activeInHierarchy)
        {
            playerscript._EkmeTusu.gameObject.SetActive(false);
        }
    }

    private void Farmer()
    {
        if (!Growing)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Seedlings[i].SetActive(true);
                Growing = true;
                StartCoroutine(Growings());
                playerscript._EkmeTusu.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator Growings()
    {
        yield return new WaitForSeconds(5);
        for (int i = 0; i < transform.childCount; i++)
        {
            Seedlings[i].SetActive(false);
            Carrots[i].SetActive(true);
        }
        yield return new WaitForSeconds(5);
        for (int i = 0; i < transform.childCount; i++)
        {
            Carrots[i].SetActive(false);
            Virgos[i].SetActive(true);
            StopCoroutine(Growings());
        }
        
    }
}
