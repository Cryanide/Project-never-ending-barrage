using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Button : MonoBehaviour
{
    public void StrtBttn(string Scene1)
    {
        SceneManager.LoadScene(Scene1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }

    public void ExitBttn()
    {
        Application.Quit();
    }

    public void MenuBttn(string Menu)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(Menu);
    }
}