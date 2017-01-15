using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreatorControl : MonoBehaviour
{
    [SerializeField]
    private GameObject skillField;
    private LanguageManager languageManager;
    [SerializeField] private Text name;
	// Use this for initialization
    void Start()
    {
        languageManager = LanguageManager.Load();
        name.text = languageManager.GetString("Name");
        ArrangeSkills();

    }

    void ArrangeSkills()
    {
        float x = -234, y = 225;
        Character character=new Character();
        for (int i = 0; i < character.Skills.Count; i++)
        {
            GameObject tempSkillField = Instantiate(skillField);
            tempSkillField.transform.parent = transform;
            tempSkillField.transform.localPosition= new Vector3(x,y);
            tempSkillField.transform.GetChild(1).GetComponent<Text>().text =
                languageManager.GetString(character.Skills[i].KeyName);
            y -= 25;
        }
    }
}
