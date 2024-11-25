using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Menu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
