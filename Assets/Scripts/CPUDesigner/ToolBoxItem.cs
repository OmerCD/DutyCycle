using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct ToolBoxItem
{
    [SerializeField]
    private string keyName;
    public string Name { get { return LanguageManager.GeneralLanguageManager.GetString(keyName); } }
    public void OnClick()
    {
        //Giving the proper item to the player
    }
}
