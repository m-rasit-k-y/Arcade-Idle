using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [Range(1,20)]
    public float Hiz;
    private Animator anim;
    public FixedJoystick joystick;
    public Image joystick_image, Handle_image;

    public Button _EkmeTusu;
    public GameObject Sack;
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
        Azalt();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Animations();
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
        }
    }

    private void Animations()
    {
        if (move)
        {
            if (control == Control.Pc)
            {
                float inputX = Input.GetAxis("Horizontal");
                float inputY = Input.GetAxis("Vertical");

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

        _EkmeTusu.onClick.AddListener(() => anim.SetTrigger("Seeding"));
        _EkmeTusu.onClick.AddListener(() => move = false);
    }

    public void Cogalt()
    {
        joystick_image.color = new Color(1, 1, 1, 1);
        Handle_image.color = new Color(1, 1, 1, 1);
    }

    public void Azalt()
    {
        joystick_image.color = new Color(1, 1, 1, 0.3f);
        Handle_image.color = new Color(1, 1, 1, 0.3f);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Farm"))
        {
            col.GetComponent<Farming>().enabled = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Farm"))
        {
            col.GetComponent<Farming>().enabled = false;
        }
    }
}
