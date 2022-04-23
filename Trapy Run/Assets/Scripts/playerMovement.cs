using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody rb;
    private float lastFrameFingerPositionX;
    public float moveFactorX;
    public float moveSpeed = 4f;
    private float swerveSpeed = 2f;
    private float maxSwerveAmount = 2f;


    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        transform.Translate(0f , 0f , moveSpeed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
        }

        float swerveAmount = Time.deltaTime * swerveSpeed * moveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmount, 0f , 0f);

        if(transform.position.x <= -3f){
            transform.position = new Vector3(-3 , transform.position.y , transform.position.z);
        }
        if(transform.position.x >= 3f){
            transform.position = new Vector3(3f , transform.position.y , transform.position.z);
        }
    }
}