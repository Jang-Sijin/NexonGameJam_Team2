using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    public void FirstButton()
    {
        SceneManager.LoadScene(1);
    }
    public void SecondButton()
    {
        //Managers.instance.
    }

    public void ThirdButton()
    {
        Application.Quit();
    }
}
