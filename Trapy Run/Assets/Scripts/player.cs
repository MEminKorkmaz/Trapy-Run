using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public Animator anim;
    public static bool isDead;
    private float timer = 0.1f;

    public GameManager gameManager;

    

    void Start(){
        isDead = false;
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update(){
        if(transform.position.y <= -3f){
            death();
        }

        if(gameManager.isGameStarted){
            anim.SetFloat("move" , 1);
        }
        else{
            anim.SetFloat("move" , 0);
        }
    }

    void OnCollisionStay(Collision col){
        if(col.gameObject.CompareTag("cubeGround")){
            timer -= Time.deltaTime;
            if(timer <= 0f){
            col.gameObject.GetComponent<cubeGround>().isTouched = true;
            col.gameObject.GetComponent<cubeGround>().speed = 4f;
            col.gameObject.GetComponent<cubeGround>().isDestroy = true;
            }
        }
    }

    void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("chaser")){
            death();
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("endGame")){
            gameManager.nextLevel();
        }
    }

    void death(){
        Invoke(nameof(restart) , 1f);
        isDead = true;
    }

    void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
