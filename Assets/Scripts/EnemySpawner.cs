﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float xLimit;
    // Start is called before the first frame update
    [SerializeField]
    private float[] xPositions;
    // [SerializeField]
    // private GameObject[] enemyPrefabs;

    [SerializeField]
    private Wave[] wave;

    private float currentTime;
    List<float> remainingPosition = new List<float>();
    private int waveIndex;
    float xPos = 0 ;
    int rand;
    void Start()
    {
        currentTime = 0;
        remainingPosition.AddRange(xPositions);
    }
    void SpawnEnemy(float xPos)
    {
        int r = Random.Range(0,7);
        //GameObject enemyObj = Instantiate(enemyPrefabs[r], new Vector3(xPos,transform.position.y,0),Quaternion.identity);
        string enemyName = "";
        if(r == 0) enemyName ="Enemy1";//"Enemy1";
        else if (r == 1) enemyName = "Enemy2";
        else if (r == 2) enemyName = "Enemy3";
        else if(r == 3) enemyName = "Points1";
        else if (r == 4) enemyName = "Points2";
        else if (r == 5) enemyName = "Points3";
        else if (r == 6) enemyName = "Power1";
        // else if (r == 7) enemyName = "Power2";
        // else if (r == 8) enemyName = "Power3";
        // else if (r == 6) enemyName = "Power1";
        // float p = Random.Range(0,100);//change
        // if(p == 0.001) enemyName = "Power1"; //change
        
        GameObject enemy = ObjectPooling.instance.GetPooledObject(enemyName);
        enemy.transform.position = new Vector3(xPos,transform.position.y, 0);
        enemy.SetActive(true);
    }

    void SelectWave()
    {
        remainingPosition = new List<float>();
        remainingPosition.AddRange(xPositions);

        waveIndex = Random.Range(0, wave.Length);

        currentTime = wave[waveIndex].delayTime;

        // if(wave[waveIndex].spawnAmount == 2)
        //     xPos = Random.Range(-xLimit,xLimit);
        // else if(wave[waveIndex].spawnAmount>2)
        // {
        rand = Random.Range(0,remainingPosition.Count);
        xPos = remainingPosition[rand];
        remainingPosition.RemoveAt(rand);
        // }
        
        for(int i= 0; i < wave[waveIndex].spawnAmount; i++)
        {
            if (MenuManager.instance.CurrentScore > 15)
                wave[waveIndex].delayTime = 1.75f;
            else if (MenuManager.instance.CurrentScore > 30)
                wave[waveIndex].delayTime = 1.50f;
            else if (MenuManager.instance.CurrentScore > 45)
                wave[waveIndex].delayTime = 1.25f;
            else if (MenuManager.instance.CurrentScore > 60)
                wave[waveIndex].delayTime = 1f;
            else if (MenuManager.instance.CurrentScore > 75)
                wave[waveIndex].delayTime = 0.75f;
            else if (MenuManager.instance.CurrentScore > 90)
                wave[waveIndex].delayTime = 0.50f;
            SpawnEnemy(xPos);
            rand = Random.Range(0,remainingPosition.Count);
            xPos = remainingPosition[rand];
            remainingPosition.RemoveAt(rand);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(PlayerC.instance.StartMoving == true)
        {
            currentTime -= Time.deltaTime;
            if(currentTime <= 0)
            {
                
                SelectWave();

            }

        } 
    }
}
[System.Serializable]
public class Wave  
{
    public float delayTime;
    public float spawnAmount;
    
}
