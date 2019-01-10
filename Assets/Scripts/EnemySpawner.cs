using System.Collections;
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
        int r = Random.Range(0,9);
        int p = Random.Range(0,3);
        string enemyName = "";

        //GameObject enemyObj = Instantiate(enemyPrefabs[r], new Vector3(xPos,transform.position.y,0),Quaternion.identity);
        if(PlayerC.instance.Runtimer2 == true)
        {
            Debug.Log("valor");
            switch(p)
            {              
                case 0: enemyName = "Points1";
                break;
                case 1:  enemyName = "Points2";
                break;
                case 2:  enemyName = "Points3";
                break;
            }
        }
        else{
            switch(r)
            {
                case 0: enemyName ="Enemy1";
                break;//"Enemy1"; 
                case 1: enemyName = "Enemy2";
                break;
                case 2: enemyName = "Enemy3";
                break;
                case 3: enemyName = "Points1";
                break;
                case 4:  enemyName = "Points2";
                break;
                case 5:  enemyName = "Points3";
                break;
                case 6: if(Random.value > 0.85) enemyName = "Power1"; 
                        else enemyName = "Enemy1"; break;
                case 7: if(Random.value > 0.95) enemyName = "Power2"; 
                        else enemyName = "Enemy2"; break;
                case 8: if(Random.value > 0.9) enemyName = "Power3"; 
                        else enemyName = "Enemy3"; break;
            }
            // else enemyName = "Enemy1";
        }
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
        foreach(Wave i in wave){
            if (MenuManager.instance.CurrentScore > 20 && MenuManager.instance.CurrentScore < 40)      
                i.delayTime = 3.5f;
            else if (MenuManager.instance.CurrentScore > 40 && MenuManager.instance.CurrentScore < 60 ){Debug.Log("30");
                i.delayTime = 3.0f;}
            else if (MenuManager.instance.CurrentScore > 60 && MenuManager.instance.CurrentScore < 80)
                i.delayTime = 2.5f;
            else if (MenuManager.instance.CurrentScore > 80 && MenuManager.instance.CurrentScore < 100)
                wave[waveIndex].delayTime = 2.0f;
            else if (MenuManager.instance.CurrentScore > 100 && MenuManager.instance.CurrentScore < 120)
                wave[waveIndex].delayTime = 1.5f;
            else if (MenuManager.instance.CurrentScore > 120)
                wave[waveIndex].delayTime = 1.0f;
            
        }
        for(int i= 0; i < wave[waveIndex].spawnAmount; i++)
        {            
                     
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
