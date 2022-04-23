using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    public float rotatingSpeed;

    
    void Update(){
        transform.Rotate(0f , rotatingSpeed * Time.deltaTime , 0f);
    }
}
