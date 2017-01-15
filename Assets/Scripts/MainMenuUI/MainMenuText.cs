using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuText : MonoBehaviour {
    [SerializeField]
    Text newGame,loadGame,settings,exit,mainMenu;

    private LanguageManager languageManager;
    // Use this for initialization
    void Start () {
		languageManager = LanguageManager.Load();
        LoadText();
	}

    public void EnglishChange()
    {
        languageManager.CurrentLanguage=LanguageManager.Language.English;
        languageManager.Save();
        LoadText();
    }

    public void TurkishChange()
    {
        languageManager.CurrentLanguage=LanguageManager.Language.Turkish;
        languageManager.Save();
        LoadText();
    }

    void LoadText()
    {
        mainMenu.text = languageManager.GetString("MainMenu");
        newGame.text = languageManager.GetString("StartNewGame");
        loadGame.text = languageManager.GetString("LoadGame");
        settings.text = languageManager.GetString("Settings");
        exit.text = languageManager.GetString("Exit");
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("CharacterCreation");
    }
}
