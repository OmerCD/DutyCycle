using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPointSliderManager : MonoBehaviour {
    UnityEngine.UI.Slider slider;
    UnityEngine.UI.Text valueText;
    int valueBefore;
    // Use this for initialization
    void Start () {
        valueText = transform.parent.GetChild(2).GetComponent<UnityEngine.UI.Text>();
        slider = GetComponent<UnityEngine.UI.Slider>();
        slider.maxValue = CharacterCreatorControl.MaxSkillPoints;
        valueBefore = (int)slider.value;
	}
    public void OnValueChanged()
    {
        if (valueBefore>slider.value)
        {
            CharacterCreatorControl.SkillPointsLeft+=valueBefore-(int)slider.value;
        }
        else
        {
            if (CharacterCreatorControl.SkillPointsLeft <= 0)
            {
                slider.value = valueBefore- CharacterCreatorControl.SkillPointsLeft;
                CharacterCreatorControl.SkillPointsLeft = 0;
            }
            else {
                CharacterCreatorControl.SkillPointsLeft-=(int)slider.value-valueBefore;
            }
        }
        valueText.text = slider.value.ToString();
        valueBefore = (int)slider.value;
    }
    void Update()
    {
        //if (CharacterCreatorControl.SkillPointsLeft <= 0)
        //{
        //    CharacterCreatorControl.SkillPointsLeft = 0;
        //    slider.value = valueBefore;
        //}
    }
}
