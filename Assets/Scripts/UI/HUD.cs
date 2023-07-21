using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType
    {
        Exp,
        Level,
        Kill,
        Time,
        Health,
    }

    public InfoType type;
    [SerializeField] private TMP_Text myTimer;
    [SerializeField] private Slider mySlider;

    void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                float curExp = Managers.instance.exp;
                float maxExp = Managers.instance.nextExp[Mathf.Min(Managers.instance.level, Managers.instance.nextExp.Length - 1)];
                // mySlider.value = curExp / maxExp;
                break;
            case InfoType.Time:
                float remainTime = Managers.instance._gameTime;
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                myTimer.text = string.Format("{0:D2}:{1:D2}", min, sec);
                break;
        }
    }

}