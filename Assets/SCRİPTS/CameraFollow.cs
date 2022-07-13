using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;

    [SerializeField] Vector3 TakipMesafesi;

    private void LateUpdate()
    {
        transform.position = Player.position + TakipMesafesi;
    }
}
