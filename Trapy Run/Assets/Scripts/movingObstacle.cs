using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingObstacle : MonoBehaviour
{
    public float moveSpeed;
    private float timer = 2.5f;
    private float tempTimer;

    
    void Start(){
        tempTimer = timer / 2f;
    }

    void Update()
    {
        tempTimer -= Time.deltaTime;
        if(tempTimer <= 0f){
            flip();
        }
        transform.Translate(moveSpeed * Time.deltaTime , 0f , 0f);
    }

    void flip(){
        moveSpeed *= -1f;
        tempTimer = timer;
    }
}
