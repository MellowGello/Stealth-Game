using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator an;
    Rigidbody rb;
    bool InAstral = false;
    float speed;
    bool Grounded = true;
    void Start()
    {
        an = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        SwitchingWorld.SwitchWorld += Switch;
        UI.ForceBack += Switch;
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 inputDirection = new Vector3(hor, 0, ver).normalized;
        speed = inputDirection.magnitude;
        
        if(speed >= 0.2f)
        {
            an.SetFloat("Speed", speed);
        }
        else
        {
            speed = 0;
            an.SetFloat("Speed", speed);
        }

        /*if (Input.GetKeyDown(KeyCode.E) && InAstral)
        {
            an.SetBool("Jump", true);
        }
        else
        {
            an.SetBool("Jump", false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Grounded = false;
            an.SetBool("Ground", false);
        }*/
    }

    void Switch()
    {
        InAstral = !InAstral;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Grounded = true;
            an.SetBool("Ground", true);
        }
    }
}
