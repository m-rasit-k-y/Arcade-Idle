using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Farming : MonoBehaviour
{

    public List<GameObject> Seedlings;
    public List<GameObject> Carrots;
    public List<GameObject> Virgos;

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


    private void Update()
    {
        if (transform.CompareTag("Sawnable") && Virgos.Count == 0)
        {
            transform.tag = "Cultivable";
            for (int i = 0; i < transform.childCount; i++)
            {
                Virgos.Add(transform.GetChild(i).GetChild(0).gameObject);

                if (i == transform.childCount - 1) break;
            }
        }
    }


    private void OnTriggerStay(Collider col)
    {
        playerscript.EkmeTusu.onClick.AddListener(() => StartCoroutine(Farmer()));

        if (col.CompareTag("Player") && transform.CompareTag("Cultivable"))
        {
            playerscript.EkmeTusu.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        playerscript.EkmeTusu.onClick.RemoveAllListeners();
        if (playerscript.EkmeTusu.gameObject.activeInHierarchy)
        {
            playerscript.EkmeTusu.gameObject.SetActive(false);
        }
    }


    IEnumerator Farmer()
    {
        playerscript.EkmeTusu.gameObject.SetActive(false);
        playerscript.Sack.SetActive(true);
        transform.tag = "Cultivated";
        yield return new WaitForSeconds(2.4f);
        for (int i = 0; i < transform.childCount; i++)
        {
            Seedlings[i].SetActive(true);
        }
        playerscript.Sack.SetActive(false);
        playerscript.anim.SetBool("Seeding", false);
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
        }
        transform.tag = "Sawnable";
        StopCoroutine(Farmer());

    }
}
