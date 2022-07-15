using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawing : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {

        if (col.tag == "Virgo")
        {
            var objects = col.GetComponentInParent<Farming>().Virgos;

            objects.Remove(col.gameObject);
            col.gameObject.SetActive(false);
        }
    }
}
