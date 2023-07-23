using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonGroup : MonoBehaviour
{
    public GameObject skillObject;

    public GameObject skillButtonObjectLeft;
    public GameObject skillButtonObjectMiddle;
    public GameObject skillButtonObjectRight;

    public Button LLevelUpButton;
    public GameObject LButtonGroup;
    public GameObject L1ButtonObject;
    public GameObject L2ButtonObject;
    public GameObject L3ButtonObject;

    private bool isClick = false;

    [SerializeField] private SkillButton[] skillButton = new SkillButton[3];
    private SkillButton skillButtonLeft;
    private SkillButton skillButtonMiddle;
    private SkillButton skillButtonRight;

    private SkillObjectManager skillObjectManager;

    void Awake()
    {
        skillObjectManager = skillObject.GetComponent<SkillObjectManager>();

        skillButtonLeft = skillButtonObjectLeft.GetComponent<SkillButton>();
        skillButtonMiddle = skillButtonObjectMiddle.GetComponent<SkillButton>();
        skillButtonRight = skillButtonObjectRight.GetComponent<SkillButton>();

        skillButton[0] = skillButtonObjectLeft.GetComponent<SkillButton>();
        skillButton[1] = skillButtonObjectMiddle.GetComponent<SkillButton>();
        skillButton[2] = skillButtonObjectRight.GetComponent<SkillButton>();
    }

    // [레벨업 시 출력되는 스킬 선택창]
    // 1: 왼쪽 스킬 선택 버튼, 2: 중앙 스킬 선택 버튼, 3: 오른쪽 스킬 선택 버튼
    public void SetSkillButtonContent(int type, Image image, string skillName, string skillLevel,
        string skillDescription)
    {
        switch (type)
        {
            case 0:
                //skillButtonLeft.skillImage = image;
                skillButtonLeft.skillName.text = skillName;
                skillButtonLeft.skillLevel.text = skillLevel;
                skillButtonLeft.skillDescription.text = skillDescription;
                break;
            case 1:
            case 2:
                //skillButtonMiddle.skillImage = image;
                skillButtonMiddle.skillName.text = skillName;
                skillButtonMiddle.skillLevel.text = skillLevel;
                skillButtonMiddle.skillDescription.text = skillDescription;
                break;
            case 3:
            case 4:
                //skillButtonRight.skillImage = image;
                skillButtonRight.skillName.text = skillName;
                skillButtonRight.skillLevel.text = skillLevel;
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

    public void SetSelectSkill()
    {
        int[] randomInt = GenerateRandomNumbers(3, 5);

        if (randomInt[0] == 0)
        {
            skillButtonLeft.skillName.text =
                skillObjectManager.BroomStickManager._skill100.skillName;

            skillButtonLeft.skillLevel.text =
                $"LV. " + skillObjectManager.BroomStickManager._skill100.skillLevel.ToString();

            skillButtonLeft.skillDescription.text =
                skillObjectManager.BroomStickManager._skill100.skillDesc;
        }
        else if (randomInt[0] == 1)
        {
            skillButtonLeft.skillName.text =
                skillObjectManager.BroomStickManager._skill110.skillName;

            skillButtonLeft.skillLevel.text =
                $"LV. " + skillObjectManager.BroomStickManager._skill110.skillLevel.ToString();

            skillButtonLeft.skillDescription.text =
                skillObjectManager.BroomStickManager._skill110.skillDesc;
        }
        else if (randomInt[0] == 2)
        {
            skillButtonLeft.skillName.text =
                skillObjectManager.BroomStickManager._skill120.skillName;

            skillButtonLeft.skillLevel.text =
                $"LV. " + skillObjectManager.BroomStickManager._skill120.skillLevel.ToString();

            skillButtonLeft.skillDescription.text =
                skillObjectManager.BroomStickManager._skill120.skillDesc;
        }
        else if (randomInt[0] == 3)
        {
            skillButtonLeft.skillName.text =
                skillObjectManager.BroomStickManager._skill130.skillName;

            skillButtonLeft.skillLevel.text =
                $"LV. " + skillObjectManager.BroomStickManager._skill130.skillLevel.ToString();

            skillButtonLeft.skillDescription.text =
                skillObjectManager.BroomStickManager._skill130.skillDesc;
        }
        else if (randomInt[0] == 4)
        {
            skillButtonLeft.skillName.text =
                skillObjectManager.BroomStickManager._skill150.skillName;

            skillButtonLeft.skillLevel.text =
                $"LV. " + skillObjectManager.BroomStickManager._skill150.skillLevel.ToString();

            skillButtonLeft.skillDescription.text =
                skillObjectManager.BroomStickManager._skill150.skillDesc;
        }
        
        if (randomInt[1] == 0)
        {
            skillButtonMiddle.skillName.text =
                skillObjectManager.BroomStickManager._skill100.skillName;

            skillButtonMiddle.skillLevel.text =
                $"LV. " + skillObjectManager.BroomStickManager._skill100.skillLevel.ToString();

            skillButtonMiddle.skillDescription.text =
                skillObjectManager.BroomStickManager._skill100.skillDesc;
        }
        else if (randomInt[1] == 1)
        {
            skillButtonMiddle.skillName.text =
                skillObjectManager.BroomStickManager._skill110.skillName;

            skillButtonMiddle.skillLevel.text =
                $"LV. " + skillObjectManager.BroomStickManager._skill110.skillLevel.ToString();

            skillButtonMiddle.skillDescription.text =
                skillObjectManager.BroomStickManager._skill110.skillDesc;
        }
        else if (randomInt[1] == 2)
        {
            skillButtonMiddle.skillName.text =
                skillObjectManager.BroomStickManager._skill120.skillName;

            skillButtonMiddle.skillLevel.text =
                $"LV. " + skillObjectManager.BroomStickManager._skill120.skillLevel.ToString();

            skillButtonMiddle.skillDescription.text =
                skillObjectManager.BroomStickManager._skill120.skillDesc;
        }
        else if (randomInt[1] == 3)
        {
            skillButtonMiddle.skillName.text =
                skillObjectManager.BroomStickManager._skill130.skillName;

            skillButtonMiddle.skillLevel.text =
                $"LV. " + skillObjectManager.BroomStickManager._skill130.skillLevel.ToString();

            skillButtonMiddle.skillDescription.text =
                skillObjectManager.BroomStickManager._skill130.skillDesc;
        }
        else if (randomInt[1] == 4)
        {
            skillButtonMiddle.skillName.text =
                skillObjectManager.BroomStickManager._skill150.skillName;

            skillButtonMiddle.skillLevel.text =
                $"LV. " + skillObjectManager.BroomStickManager._skill150.skillLevel.ToString();

            skillButtonMiddle.skillDescription.text =
                skillObjectManager.BroomStickManager._skill150.skillDesc;
        }
        
        if (randomInt[2] == 0)
        {
            skillButtonRight.skillName.text =
                skillObjectManager.BroomStickManager._skill100.skillName;

            skillButtonRight.skillLevel.text =
                $"LV. " + skillObjectManager.BroomStickManager._skill100.skillLevel.ToString();

            skillButtonRight.skillDescription.text =
                skillObjectManager.BroomStickManager._skill100.skillDesc;
        }
        else if (randomInt[2] == 1)
        {
            skillButtonRight.skillName.text =
                skillObjectManager.BroomStickManager._skill110.skillName;

            skillButtonRight.skillLevel.text =
                $"LV. " + skillObjectManager.BroomStickManager._skill110.skillLevel.ToString();

            skillButtonRight.skillDescription.text =
                skillObjectManager.BroomStickManager._skill110.skillDesc;
        }
        else if (randomInt[2] == 2)
        {
            skillButtonRight.skillName.text =
                skillObjectManager.BroomStickManager._skill120.skillName;

            skillButtonRight.skillLevel.text =
                $"LV. " + skillObjectManager.BroomStickManager._skill120.skillLevel.ToString();

            skillButtonRight.skillDescription.text =
                skillObjectManager.BroomStickManager._skill120.skillDesc;
        }
        else if (randomInt[2] == 3)
        {
            skillButtonRight.skillName.text =
                skillObjectManager.BroomStickManager._skill130.skillName;

            skillButtonRight.skillLevel.text =
                $"LV. " + skillObjectManager.BroomStickManager._skill130.skillLevel.ToString();

            skillButtonRight.skillDescription.text =
                skillObjectManager.BroomStickManager._skill130.skillDesc;
        }
        else if (randomInt[2] == 4)
        {
            skillButtonRight.skillName.text =
                skillObjectManager.BroomStickManager._skill150.skillName;

            skillButtonRight.skillLevel.text =
                $"LV. " + skillObjectManager.BroomStickManager._skill150.skillLevel.ToString();

            skillButtonRight.skillDescription.text =
                skillObjectManager.BroomStickManager._skill150.skillDesc;
        }
        // 140빼기 
        // 100 110 120 130 150
    }

// 중복없는 난수 3개를 뽑아내는 함수
    int[] GenerateRandomNumbers(int getCount, int maxNumber)
    {
        int[] randomNumbers = new int[getCount];
        for (int i = 0; i < getCount; i++)
        {
            int randomNumber;
            bool isDuplicate;

            do
            {
                // 1부터 maxNumber까지의 난수를 뽑습니다.
                randomNumber = Random.Range(0, maxNumber);

                // 뽑힌 난수가 배열에 이미 존재하는지 체크
                isDuplicate = false;
                for (int j = 0; j < i; j++)
                {
                    if (randomNumbers[j] == randomNumber)
                    {
                        isDuplicate = true;
                        break;
                    }
                }
            } while (isDuplicate);

            // 중복이 아닌 난수를 배열에 추가
            randomNumbers[i] = randomNumber;
        }

        return randomNumbers;
    }
}