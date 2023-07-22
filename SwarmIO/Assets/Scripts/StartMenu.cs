using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject tutorial;
    private bool tutorialOn;
    public void playGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void toggleTutorial()
    {
        if (tutorialOn)
        {
            tutorial.SetActive(false);
            tutorialOn = false;
        }
        else if (!tutorialOn)
        {
            tutorial.SetActive(true);
            tutorialOn = true;
        }
    }
}
