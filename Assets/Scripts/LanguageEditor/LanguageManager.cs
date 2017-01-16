using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[XmlRoot("LanguageManager")]
public class LanguageManager
{
    public static LanguageManager GeneralLanguageManager;
    [XmlEnum("CurrentLanguage")]
    public Language CurrentLanguage;
    [XmlArray("Translations"),XmlArrayItem("Translation")]
    public List<Translation> Translations;
    static readonly string globalFilePath = Path.Combine(Application.dataPath, "Resources/Xml/Languages.xml");
    public enum Language
    {
        English,
        Turkish
    }
       
    public LanguageManager()
    {
        CurrentLanguage = Language.English;
        Translations = new List<Translation>();
    }
    #region Basic Operations
    public void AddTranslation(Translation translation)
    {
        Insert(translation, true);
    }

    public void UpdateTranslation(Translation translation)
    {
        Insert(translation, false);
    }
    public string GetString(string key)
    {
        int i = FindKey(key);
        return i != -1 ? Translations[i].GetValue(CurrentLanguage) : key;
    }

    public string GetString(string key, Language language)
    {
        int i = FindKey(key);
        return i != -1 ? Translations[i].GetValue(language) : key;
    }
    void Insert(Translation translation, bool add)
    {
        int i = FindKey(translation.Key);
        if (i != -1)
        {
            if (add) return;
            Translations[i] = translation;
        }
        if (add)
        {
            Translations.Add(translation);
        }
    }

    public void Remove(Translation translation)
    {
        Translations.Remove(translation);
    }
    public void Remove(int index)
    {
        Translations.RemoveAt(index);
    }

    public void Remove(string key)
    {
        for (int i = 0; i < Translations.Count; i++)
        {
            if (Translations[i].Key.Equals(key))
            {
                Translations.RemoveAt(i);
                break;
            }
        }
    }
    public int FindKey(string key)
    {
        for (int i = 0; i < Translations.Count; i++)
        {
            if (Translations[i].Key.Equals(key))
            {
                return i;
            }
        }
        return -1;
    }
    public bool ContainsKey(string key)
    {
        return FindKey(key) >= 0;
    }

    #endregion

    #region Save & Load
    public void Save()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(LanguageManager));
        using (FileStream stream = new FileStream(globalFilePath, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }
    public static LanguageManager Load()
    {
        if (File.Exists(globalFilePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(LanguageManager));
            using (FileStream stream = new FileStream(globalFilePath, FileMode.Open))
            {
                return serializer.Deserialize(stream) as LanguageManager;
            }
        }
        return new LanguageManager();
    }
    #endregion
}
