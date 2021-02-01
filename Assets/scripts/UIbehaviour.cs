using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIbehaviour : MonoBehaviour
{
    public GameObject menuUI;
    bool pauseMenuIsClosed = true;
    public void PauseMenu()
    {
        print("hello");
        if(pauseMenuIsClosed)
        {
            print("hello 2");
            menuUI.SetActive(true);
            Time.timeScale = 0;
            pauseMenuIsClosed = false;
        }
        else
        {
            print("hello3");
            menuUI.SetActive(false);
            Time.timeScale = 1;
            pauseMenuIsClosed = true;
        }
        
    }

    public void QuitOnBackButton()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
   public void PlayNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
   public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    
   public void Quit()
    {
        Application.Quit();
    }

    private void Update()
    {
        QuitOnBackButton();
    }
}
