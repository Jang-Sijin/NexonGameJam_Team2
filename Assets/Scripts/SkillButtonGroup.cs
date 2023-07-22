using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonGroup : MonoBehaviour
{
    public GameObject skillButtonObjectLeft;
    public GameObject skillButtonObjectMiddle;
    public GameObject skillButtonObjectRight;

    public Button LLevelUpButton;
    public GameObject L1ButtonObject;
    public GameObject L2ButtonObject;
    public GameObject L3ButtonObject;

    private bool isClick = false;

    private SkillButton skillButtonLeft;
    private SkillButton skillButtonMiddle;
    private SkillButton skillButtonRight;

    void Start()
    {
        skillButtonLeft = skillButtonObjectLeft.GetComponent<SkillButton>();
        skillButtonMiddle = skillButtonObjectMiddle.GetComponent<SkillButton>();
        skillButtonRight = skillButtonObjectRight.GetComponent<SkillButton>();
    }

    // [레벨업 시 출력되는 스킬 선택창]
    // 1: 왼쪽 스킬 선택 버튼, 2: 중앙 스킬 선택 버튼, 3: 오른쪽 스킬 선택 버튼
    public void SetSkillButtonContent(int type, Image image, string skillName, string skillDescription)
    {
        switch (type)
        {
            case 1:
                skillButtonLeft.skillImage = image;
                skillButtonLeft.skillName.text = skillName;
                skillButtonLeft.skillDescription.text = skillDescription;
                break;
            case 2:
                skillButtonMiddle.skillImage = image;
                skillButtonMiddle.skillName.text = skillName;
                skillButtonMiddle.skillDescription.text = skillDescription;
                break;
            case 3:
                skillButtonRight.skillImage = image;
                skillButtonRight.skillName.text = skillName;
                skillButtonRight.skillDescription.text = skillDescription;
                break;
        }
    }
    
    // 이벤트 처리할 함수
    private void OnButtonClick()
    {
        isClick = !isClick;

        if (isClick == true)
        {
            L1ButtonObject.SetActive(true);
            L2ButtonObject.SetActive(true);
            L3ButtonObject.SetActive(true);
        }
        else
        {
            L1ButtonObject.SetActive(false);
            L2ButtonObject.SetActive(false);
            L3ButtonObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        // 버튼 컴포넌트에 클릭 이벤트 핸들러 등록
        LLevelUpButton.onClick.AddListener(OnButtonClick);
    }
    private void OnDisable()
    {
        // 버튼 컴포넌트에서 클릭 이벤트 핸들러 제거
        LLevelUpButton.onClick.RemoveListener(OnButtonClick);
    }
}
