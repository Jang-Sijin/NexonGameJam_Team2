using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    public void FirstButton()
    {
        SoundManager.Instance.PlaySFXSound("Button");
        SceneManager.LoadScene("InfiniteMap2");
    }
    public void SecondButton()
    {
        SoundManager.Instance.PlaySFXSound("Button");
        //Managers.instance.
    }

    public void ThirdButton()
    {
        SoundManager.Instance.PlaySFXSound("Button");
        Application.Quit();
    }
}
