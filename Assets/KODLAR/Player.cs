using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [Range(1,20)]
    public float Hiz;
    public Animator anim;
    public FixedJoystick joystick;
    public Image joystick_image, Handle_image;
    public enum Control
    {
        Pc,
        Mobile
    }
    public Control control;

    private void Awake()
    {
        Azalt();
    }
    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        Animations();
    }

    private void Movement()
    {
        if (control == Control.Pc)
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");

            Vector3 MovDirection = new Vector3(inputX, 0, inputY);
            MovDirection.Normalize();

            transform.Translate(MovDirection * Hiz * Time.deltaTime, Space.World);

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

        // PC
        // Mobile


    }

    private void Animations()
    {
        // PC
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
}
