using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityStandardAssets;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour
{

   public float speed = 5;
    public float FSpeed = 5;
   public Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 2;

    bool colliding = false;
    private void Start()
    {
        
    }
    void FixedUpdate()
    {
        FSpeed += 0.1f * Time.deltaTime;
        Vector3 forwardMove = transform.forward * FSpeed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);

        if (rb.position.y < -1.77f)
        {
            if (colliding == true)
            {
                heartControl.deathCounter = heartControl.deathCounter;
            }
            else
            {
                heartControl.deathCounter += 1;
                colliding = true;
            }
            
            
            FindObjectOfType<PlayerManager>().endGame();
        }
    }

    private void Update()
    {
        horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");

        
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "obstacles")
        {
            if (colliding == true)
            {
                heartControl.deathCounter = heartControl.deathCounter;
            }
            else
            {
                heartControl.deathCounter += 1;
                colliding = true;
            }
            
            
            
            
            FindObjectOfType<PlayerManager>().endGame();
            
            
        }
    }

  


    }
