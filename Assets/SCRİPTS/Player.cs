using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Sawing
{
    [Range(1,20)]
    public float Hiz;
    [HideInInspector]
    public Animator anim;
    public FloatingJoystick joystick;

    public Button EkmeTusu;
    public GameObject Sack;
    public GameObject Scythe;
    [HideInInspector]
    public bool move = true;
    public enum Control
    {
        Pc,
        Mobile
    }
    public Control control;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (move)
        {
            Movement();
        }
    }

    private void Movement()
    {
        if (control == Control.Pc)
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");

            Vector3 MovDirection = new Vector3(inputX, 0, inputY);

            transform.Translate(MovDirection.normalized * Hiz * Time.deltaTime, Space.World);

            if (MovDirection != Vector3.zero)
            {
                transform.forward = MovDirection;
            }

            Vector3 StickDirection = new Vector3(inputX, 0, inputY);

            float toplamhiz = Vector3.ClampMagnitude(StickDirection, 0.1f).magnitude;

            if (toplamhiz > 0.01f)
            {
                anim.SetBool("Run", true);
            }
            else
            {
                anim.SetBool("Run", false);
            }
        }
        else if (control == Control.Mobile)
        {
            float inputX = joystick.Horizontal;
            float inputY = joystick.Vertical;

            Vector3 MovDirection = new Vector3(inputX, 0, inputY);
            MovDirection.Normalize();

            transform.Translate(MovDirection * Hiz * Time.deltaTime, Space.World);

            if (MovDirection != Vector3.zero)
            {
                transform.forward = MovDirection;
            }

            Vector3 StickDirection = new Vector3(inputX, 0, inputY);

            float toplamhiz = Vector3.ClampMagnitude(StickDirection, 0.1f).magnitude;

            if (toplamhiz > 0.01f)
            {
                anim.SetBool("Run", true);
            }
            else
            {
                anim.SetBool("Run", false);
            }
        }
    }

    public void Animations(string state)
    {
        switch (state)
        {
            case "Seeding":
                anim.SetBool("Seeding", true);
                move = false;
                break;
            case "Sawing":
                anim.SetTrigger("Sawing");
                move = false;
                break;
            case "Idle":
                move = true;
                break;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Cultivable")|| col.CompareTag("Sawnable"))
        {
            col.GetComponent<Farming>().enabled = true;
        }
        if (col.CompareTag("Sawnable") || col.CompareTag("Virgo"))
        {
            Scythe.SetActive(true);
            anim.SetBool("Sawing", true);
            Hiz = 3;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Cultivable") || col.CompareTag("Sawnable"))
        {
            col.GetComponent<Farming>().enabled = false;

            Scythe.SetActive(false);
            anim.SetBool("Sawing", false);
            Hiz = 8;
        }
    }
}
