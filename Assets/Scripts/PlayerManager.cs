using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using GoogleMobileAds;

public class PlayerManager : MonoBehaviour
{

    public GameObject Panel;

    public static int numberofFoods;

    public Text foodText;

    public Text highScore;

    public Text yourscore;

    bool gameEnded = false;

    


    void Start()
    {
        TinySauce.OnGameStarted();
        
        
        numberofFoods = 0;
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        //if (heartControl.deathCounter == 3)
        //{
            
        //    FindObjectOfType<AdsControl>().showAds1();
            

        //}

        FindObjectOfType<AudioManager>().playSound("MainTheme");

    }


    void Update()
    {
        foodText.text ="" + numberofFoods;
        yourscore.text = "" + numberofFoods;

        if (numberofFoods > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", numberofFoods);
            highScore.text = numberofFoods.ToString();
            TinySauce.OnGameFinished(numberofFoods);
        }

        


    }

   public void endGame()
    {
        if (gameEnded == false)
        {
            

            if (heartControl.deathCounter == 5)
            {

                
                gameEnded = true;
                
                Invoke("gameOver", 2.0f);
                

            }
            else
            {
                gameEnded = true;
                Invoke("Restart", 2.0f);
            }
            

        }

        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
       

    }

    public void gameOver()
    {
        if (Panel != null)
        {
            Panel.SetActive(true);
            
            Time.timeScale = 0f;
            

        }
        
    }
    
}
