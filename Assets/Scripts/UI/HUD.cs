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
    private TMP_Text _myText;
    private Slider _mySlider;

    private void Awake()
    {
        _myText = GetComponent<TMP_Text>();
        _mySlider = GetComponent<Slider>();
    }

    void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                float curExp = Managers.instance.exp;
                float maxExp = Managers.instance.nextExp[Mathf.Min(Managers.instance.level, Managers.instance.nextExp.Length - 1)];
                _mySlider.value = curExp / maxExp;
                break;
            case InfoType.Level:
                _myText.text = string.Format("Lv.{0:F0}", Managers.instance.level);
                break;
            case InfoType.Time:
                float remainTime = Managers.instance._gameTime;
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                _myText.text = string.Format("{0:D2}:{1:D2}", min, sec);
                break;
            case InfoType.Health:
                float curHealth = Managers.instance.health;
                float maxHealth = Managers.instance.maxHealth;
                _mySlider.value = curHealth / maxHealth;
                break;
        }
    }
}