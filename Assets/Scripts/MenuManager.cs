using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField]
    private Text scoreText, goScoreText, multiplierText;
    [SerializeField]
    private GameObject gameOverMenu;
    private int currentScore;
    public int CurrentScore{get{return currentScore;}}
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
            instance = this;  
    }
    void Start()
    {
        multiplierText.gameObject.SetActive(false);
        scoreText.text = "" + 0;
    }
    
    public void IncreaseScore()
    {
        if (PlayerC.instance.Runtimer == true) 
        {
            currentScore += PlayerC.instance.Score * 2;
        }
        else {
            currentScore += PlayerC.instance.Score;
        }
        scoreText.text = "" + currentScore;
    }
    public void ShowStatusEffect()
    {
        multiplierText.gameObject.SetActive(true);
    }
    public void RemoveStatusEffect()
    {
        multiplierText.gameObject.SetActive(false);
    }

    public void ReplayBtn()
    {
        SoundManager.instance.PlayClick();
        Debug.Log("replay");
        Health.health = 3;
        // gameOverMenu.SetActive(false);
        PlayerC.instance.StartMoving = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerC.instance.StartMoving = true;
    }

    public void HomeBtn()
    {
        SoundManager.instance.PlayClick();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Debug.Log("works");
    }

    public void GameOver()
    {
        // gameOverMenu.SetActive(true);
        goScoreText.text = "" + currentScore;
        PlayerC.instance.gameObject.SetActive(false);
    }
    // Update is called once per frame
    
}
