using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaser : MonoBehaviour
{
    public float moveSpeed;
    void Update()
    {
        transform.Translate(0f , 0f , moveSpeed * Time.deltaTime);
        death();
    }

    void death(){
        if(transform.position.y <= -50f){
            Destroy(gameObject);
        }
    }
}
