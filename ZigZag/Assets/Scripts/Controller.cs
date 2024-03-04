using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] GameObject virtualCamera;
    Rigidbody rb;

    [Header("Settings")]
    [SerializeField] private float speed;
    private bool isStarted;
    private bool isGameOver;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        if (!isStarted) 
        { 
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0); // степень изменения позиции
                isStarted = true;
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red, 3f);

        if (Physics.Raycast(transform.position, Vector3.down, 4f) == false)
        {
            isGameOver = true;
            rb.constraints = RigidbodyConstraints.None;
            rb.velocity = new Vector3(0, -25, 0);
            virtualCamera.SetActive(false);
        }


        if (Input.GetMouseButtonDown(0) && !isGameOver)
        {
            SwitchDirection();
        }

    }

    private void SwitchDirection()
    {
        if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3 (speed, 0, 0);
        }
        else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }
}
