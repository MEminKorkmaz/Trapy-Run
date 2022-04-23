using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] maps;

    public int setAmount;
    public int setIntervals;

    private Vector3 setPos;

    private GameObject tempGO;
    
    public GameObject firstMap;



    void Start(){
        setPos = new Vector3(0f , 1.5f , 10f);
        Shuffle();
        Placement();
        MapPlacement();
    }




    void Shuffle() {
        for (int i = 0; i < obstacles.Length; i++) {
            int rnd = Random.Range(0, obstacles.Length);
            tempGO = obstacles[rnd];
            obstacles[rnd] = obstacles[i];
            obstacles[i] = tempGO;
        }
    }

    void Placement(){
        for(int i = 0; i < setAmount; i++){
            int x = Random.Range(0 , 3);
            if(x == 0 || x == 2)
            Instantiate(obstacles[i] , setPos , Quaternion.identity);
            setPos.z += setIntervals;
        }
    }

    void MapPlacement(){
        Vector3 mapPos = new Vector3(0f , 0f , 0f);
        if(PlayerPrefs.GetInt("level" , 1) == 1){
            return;
        }
        else{
        if(firstMap != null){
            Destroy(firstMap);
        }
        int rnd = Random.Range(0 , 3);
        Instantiate(maps[rnd] , mapPos , Quaternion.identity);
        }
    }
}
