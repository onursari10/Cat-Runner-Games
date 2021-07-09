using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayAgain : MonoBehaviour
{

    [SerializeField] float startTime = 5f;
    [SerializeField] Text timerText;

    float timer;

    

    void Start()
    {
        timer = startTime;

    }


    public void PlayAgainTimer()
    {
        Time.timeScale = 1f;
            StartCoroutine(Timer());
            Debug.Log("geri sayim");
            
        
    }

    public IEnumerator Timer()
    {
        

        do
        {
            timer -= Time.deltaTime;
            formatText();
            yield return null;
        } while (timer > 0);
    }

    void formatText()
    {
        int minutes = (int)(timer / 60) % 60;
        int seconds = (int)(timer % 60);

        timerText.text = "";

        if (minutes > 0)
        {
            timerText.text += minutes + "m";
        }
        if (seconds > 0)
        {
            timerText.text += seconds + "s";
        }

    }
    private void Update()
    {
        
        
    }
    
}
