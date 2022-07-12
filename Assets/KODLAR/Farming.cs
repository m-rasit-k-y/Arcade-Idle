using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Farming : MonoBehaviour
{
    public List<GameObject> Seedlings;
    public List<GameObject> Carrots;
    public List<GameObject> Virgos;
    private bool Growing;
    public GameObject EkmeTusu;

    private void Awake()
    {
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

    }


    private void OnTriggerStay(Collider col)
    {

        if (col.CompareTag("Player") && !Growing)
        {
            EkmeTusu.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (EkmeTusu.activeInHierarchy)
        {
            EkmeTusu.SetActive(false);
        }
    }

    public void Farmer(bool seedling)
    {

        if (seedling && !Growing)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Seedlings[i].SetActive(true);
                Growing = true;
                StartCoroutine(Growings());
                EkmeTusu.SetActive(false);
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
