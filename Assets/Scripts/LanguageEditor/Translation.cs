using System.Xml.Serialization;

public class Translation
{
    [XmlAttribute("Key")]
    public string Key;
    [XmlElement("English")]
    public string English;
    [XmlElement("Turkish")]
    public string Turkish;

    public Translation()
    {
        Key = "New Key";
        English = string.Empty;
        Turkish = string.Empty;
    }
    internal string GetValue(LanguageManager.Language language)
    {
        switch (language)
        {
                case LanguageManager.Language.English:
                return English;
                case LanguageManager.Language.Turkish:
                return Turkish;
            default:
                return string.Empty;
        }
    }
}
