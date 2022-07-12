using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farming : MonoBehaviour
{
    public GameObject Level_0_Prefab;

    void Start()
    {
        
    }
    private void Update()
    {
        FarmLevels();
    }

    public void FarmLevels()
    {

    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    //Instantiate(Level_0_Prefab, transform);
                    Debug.Log(i);
                }
            }
        }
    }
}
