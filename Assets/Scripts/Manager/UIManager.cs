using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject settingsPanelObject;
    public GameObject selectSkillPanelObject;
    [SerializeField] private bool isKeyDown = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            isKeyDown = !isKeyDown;

        if (isKeyDown == true)
        {
            settingsPanelObject.SetActive(true);
            UIFreeze();
        }
        else
        {
            settingsPanelObject.SetActive(false);
            UIUnfreeze();
        }
    }
    
    public void UIOpenSelectSkillMenu()
    {
        selectSkillPanelObject.SetActive(true);
        UIFreeze();
    }
    
    public void UICloseSelectSkillMenu()
    {
        selectSkillPanelObject.SetActive(false);
        UIUnfreeze();
    }

    public void UIFreeze()
    {
        Time.timeScale = 0f;
    }

    public void UIUnfreeze()
    {
        Time.timeScale = 1f;
    }
}
