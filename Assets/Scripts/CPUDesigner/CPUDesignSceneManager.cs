using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPUDesignSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject _toolBoxItemPrefab;
    [SerializeField] private Transform _toolBoxArea;
    public List<ToolBoxItem> ToolBoxItems;
    void Awake()
    {
        LanguageManager.GeneralLanguageManager=LanguageManager.Load();
    }

    void Start()
    {
        foreach (var toolBoxItem in ToolBoxItems)
        {
            Transform tempItem = Instantiate(_toolBoxItemPrefab).transform;
            tempItem.GetChild(0).GetComponent<Text>().text = toolBoxItem.Name;
            tempItem.parent = _toolBoxArea;
        }
    }
}
