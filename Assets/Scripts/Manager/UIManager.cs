using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject settingsPanelObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingsPanelObject.SetActive(true);
            UIFreeze();
        }
    }

    public void UIFreeze()
    {
        Time.timeScale = 0;
    }

    public void UIUnfreeze()
    {
        Time.timeScale = 1;
    }
}
