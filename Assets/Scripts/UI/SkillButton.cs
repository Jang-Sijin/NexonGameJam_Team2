using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public SkillObjectManager skillObjectManager;
    public Image skillImage;
    public TMP_Text skillName;
    public TMP_Text skillLevel;
    public TMP_Text skillDescription;

    private void Start()
    {
        //this.gameObject.GetComponent<Button>().onClick()
    }

    public void OnClickBtn()
    {
        if (skillName.text == skillObjectManager.BroomStickManager._skill100.skillName)
        {
            skillObjectManager.BroomStickManager.LevelUp(skillObjectManager.BroomStickManager._skill100);
        }
        else if (skillName.text == skillObjectManager.BroomStickManager._skill110.skillName)
        {
            skillObjectManager.BroomStickManager.LevelUp(skillObjectManager.BroomStickManager._skill110);
        }
        else if (skillName.text == skillObjectManager.BroomStickManager._skill120.skillName)
        {
            skillObjectManager.BroomStickManager.LevelUp(skillObjectManager.BroomStickManager._skill120);
        }
        else if (skillName.text == skillObjectManager.BroomStickManager._skill130.skillName)
        {
            skillObjectManager.BroomStickManager.LevelUp(skillObjectManager.BroomStickManager._skill130);
        }
        else if (skillName.text == skillObjectManager.BroomStickManager._skill140.skillName)
        {
            skillObjectManager.BroomStickManager.LevelUp(skillObjectManager.BroomStickManager._skill140);
        }
        else if (skillName.text == skillObjectManager.BroomStickManager._skill150.skillName)
        {
            skillObjectManager.BroomStickManager.LevelUp(skillObjectManager.BroomStickManager._skill150);
        }
        
        UIManager.instance.selectSkillPanelObject.SetActive(false);
    }
}