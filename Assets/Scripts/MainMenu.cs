using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public void PlayNowButton()
    {
  
        SceneManager.LoadScene("PlayScene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
