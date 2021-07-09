using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class heartControl : MonoBehaviour
{
    public GameObject kalp1, kalp2, kalp3,kalp4,kalp5;
    public static int deathCounter;

    
    void Start()
    {

        deathCounter = PlayerPrefs.GetInt("kalp", 0);
        
    }

    void Update()
    {
        if (deathCounter == 1)
        {
            Destroy(kalp1);
            PlayerPrefs.SetInt("kalp", deathCounter);
        }

        if (deathCounter == 2)
        {
            if (kalp1 != null)
            {
                kalp1.SetActive(false);
            }
            
            Destroy(kalp2);
            PlayerPrefs.SetInt("kalp", deathCounter);

        }

        if (deathCounter == 3)
        {
            if (kalp1 != null)
            {
                kalp1.SetActive(false);
            }
            if (kalp2 != null)
            {
                kalp2.SetActive(false);
            }
            
            Destroy(kalp3);
            PlayerPrefs.SetInt("kalp", deathCounter);
        }

        if (deathCounter == 4)
        {
            if (kalp1 != null)
            {
                kalp1.SetActive(false);
            }
            if (kalp2 != null)
            {
                kalp2.SetActive(false);
            }
            if (kalp3 != null)
            {
                kalp3.SetActive(false);
            }
            

            Destroy(kalp4);
            PlayerPrefs.SetInt("kalp", deathCounter);
        }

        if (deathCounter == 5)
        {
            if (kalp1 != null)
            {
                kalp1.SetActive(false);
            }
            if (kalp2 != null)
            {
                kalp2.SetActive(false);
            }
            if (kalp3 != null)
            {
                kalp3.SetActive(false);
            }
            if (kalp4 != null)
            {
                kalp4.SetActive(false);
            }

            Destroy(kalp5);
            PlayerPrefs.SetInt("kalp", deathCounter);
        }

        if (deathCounter == 5)
        {
            
            PlayerPrefs.DeleteKey("kalp");
        }

    }
}
