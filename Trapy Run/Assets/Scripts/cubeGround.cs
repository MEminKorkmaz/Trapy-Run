using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeGround : MonoBehaviour
{
    
    [HideInInspector]
    public float speed;

    [HideInInspector]
    public bool isDestroy;

    [HideInInspector]
    public bool isTouched;

    [HideInInspector]
    public Renderer cubeRenderer;
    
    
    void Start(){
        cubeRenderer = this.GetComponent<Renderer>();
    }

    void Update(){
        if(isTouched){
            cubeRenderer.material.SetColor("_Color", Color.red);
            Invoke(nameof(move) , 0.1f);
        }

        if(isDestroy){
            Destroy(gameObject , 5f);
        }
    }

    void move(){
        transform.Translate(0f , -speed * Time.deltaTime , 0f);
    }
}
