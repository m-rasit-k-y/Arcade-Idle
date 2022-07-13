using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawing : MonoBehaviour
{
    private bool sawn = false;
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Virgo") && sawn)
        {
            Destroy(col.gameObject);
        }
    }

    public void Saw(int state)
    {
        if (state == 0)
        {
            sawn = false;
        }
        else
        {
            sawn = true;
        }
    }
}
