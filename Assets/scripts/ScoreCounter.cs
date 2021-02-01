using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text score, timer;
    public GameObject[] balloons;
    float timeInMin, timeLeft = 30;
    int initialBalloonsNumber = 25;
    public GameObject menuUI, diedText, playNext;
    GameObject[] bombs;
    public Text finalScore , finalScoreText;
    public Button fire, scope , menu;
    // Update is called once per frame


    void Update()
    {
        bombs = GameObject.FindGameObjectsWithTag("Bomb");
        //   timeInMin = (int)Time.time;
        timeLeft = timeLeft - Time.deltaTime;
        balloons = GameObject.FindGameObjectsWithTag("Balloons");
        score.text = balloons.Length.ToString();
        // timer.text = timeLeft.ToString("F2");
        if (timeLeft <= 0 || balloons.Length == 0)
        {
            menuUI.SetActive(true);
            finalScore.enabled = true;
            finalScoreText.enabled = true;
            finalScore.text = (initialBalloonsNumber - balloons.Length).ToString();
            if(balloons.Length == 0)
            {
                playNext.SetActive(true);
            }
            fire.enabled = false;
            scope.enabled = false;
            menu.enabled = false;
        }
        else
        {
            menuUI.SetActive(false);
            finalScore.enabled = false;
            finalScoreText.enabled = false;
            timer.text = timeLeft.ToString("F2");
            fire.enabled = true;
            scope.enabled = true;
            menu.enabled = true;
        }
        if (bombs.Length < 3)
        {
            menuUI.SetActive(true);
            finalScore.enabled = true;
            finalScoreText.enabled = true;
            finalScore.text = (initialBalloonsNumber - balloons.Length).ToString();
            diedText.SetActive(true);
            fire.enabled = false;
            scope.enabled = false;
            menu.enabled = false;
        }
       /* else
        {
            fire.enabled = true;
            scope.enabled = true;
        }*/
    }
}
