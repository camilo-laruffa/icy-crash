using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueForce = 13f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float flipSpeed = 1.2f;
    [SerializeField] ParticleSystem flipEffect;
    [SerializeField] AudioSource flipSound;
    SurfaceEffector2D surfaceEffector;
    bool canMove = true;
    float baseSpeed;
    float currentSpeed;
    float boostTimer = 0;
    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
        baseSpeed = surfaceEffector.speed;
        currentSpeed = baseSpeed;
        rb2d.rotation = 0;
    }

    public void DisableControls()
    {
        canMove = false;
    }
    void FixedUpdate()
    {
        if (canMove)
        {
            RotatePlayer();
            ManageMovement();
            if(boostTimer > 0f)
            {
                boostTimer -= Time.deltaTime;
            }
            else
            {
                boostTimer = 0f;
                currentSpeed = baseSpeed;
            }
            Debug.Log(boostTimer);
        }
    }

    void ManageMovement()
    {
        surfaceEffector.speed = currentSpeed;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector.speed = currentSpeed + boostSpeed;
        }
        if (rb2d.rotation <= -360 || rb2d.rotation >= 360)
        {
            ManageFlip();
        }
    }
    void ManageFlip()
    {
        rb2d.rotation = 0;
        boostTimer = 5f;
        currentSpeed = baseSpeed * flipSpeed;
        flipEffect.Play();
    }
    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueForce);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueForce);
        }
    }
}

