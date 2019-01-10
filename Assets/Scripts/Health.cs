
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public GameObject lives, lives1, lives2,liveD, liveD1, liveD2, gameOver;
    public static int health = 3;

    void Update()
    {
        if (health > 3)
            health = 3;

        switch (health)
        {
        case 3:
            // Debug.Log("Case3");
            lives.gameObject.SetActive(true);
            lives1.gameObject.SetActive(true);
            lives2.gameObject.SetActive(true);
            liveD.gameObject.SetActive(false);
            liveD1.gameObject.SetActive(false);
            liveD2.gameObject.SetActive(false);
            break;
        
        case 2:
            // Debug.Log("Case2");
            lives.gameObject.SetActive(true);
            lives1.gameObject.SetActive(true);
            lives2.gameObject.SetActive(false);
            liveD.gameObject.SetActive(true);
            liveD1.gameObject.SetActive(false);
            liveD2.gameObject.SetActive(false);
            break;
        
        case 1:
        // Debug.Log("Case1");
            lives.gameObject.SetActive(true);
            lives1.gameObject.SetActive(false);
            lives2.gameObject.SetActive(false);
            liveD.gameObject.SetActive(true);
            liveD1.gameObject.SetActive(true);
            liveD2.gameObject.SetActive(false);
            break;

        case 0:
        // Debug.Log("Case0");
            lives.gameObject.SetActive(false);
            lives1.gameObject.SetActive(false);
            lives2.gameObject.SetActive(false);
            liveD.gameObject.SetActive(true);
            liveD1.gameObject.SetActive(true);
            liveD2.gameObject.SetActive(true);
            gameOver.gameObject.SetActive(true);
            gameObject.SetActive(false);
            MenuManager.instance.GameOver();
            // Time.timeScale = 0f;
            break;
            
        }
    }

}
