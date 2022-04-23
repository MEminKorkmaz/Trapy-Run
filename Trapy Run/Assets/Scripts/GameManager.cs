using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public Text levelTxt;
    public Text tutorialTxt;
    public Text clickToPlayTxt;
    public Text gameOverTxt;

    public bool isGameStarted;

    void Start(){
        isGameStarted = false;
        tutorialTxt.gameObject.SetActive(false);
        clickToPlayTxt.gameObject.SetActive(false);
        gameOverTxt.gameObject.SetActive(false);
    }


    void Update(){
        if(Input.GetMouseButtonDown(0)){
            isGameStarted = true;
        }

        levelTxt.text = "Level " + PlayerPrefs.GetInt("level" , 1).ToString();
        if(PlayerPrefs.GetInt("level" , 1) == 1){
            tutorialTxt.gameObject.SetActive(true);
        }
        else{
            tutorialTxt.gameObject.SetActive(false);
            clickToPlayTxt.gameObject.SetActive(true);
        }
        if(isGameStarted){
            tutorialTxt.gameObject.SetActive(false);
            clickToPlayTxt.gameObject.SetActive(false);
        }

        if(!isGameStarted){
            Time.timeScale = 0f;
        }
        else{
            Time.timeScale = 1f;
        }

        if(player.isDead){
            gameOverTxt.gameObject.SetActive(true);
            if(Input.GetMouseButtonDown(0)){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        else{
            gameOverTxt.gameObject.SetActive(false);
        }
    }

    public void nextLevel(){
        int level = PlayerPrefs.GetInt("level" , 1);
        level++;
        PlayerPrefs.SetInt("level" , level);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isGameStarted = false;
    }
}
