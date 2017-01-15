using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class Character : Person {
    protected sealed override void Save()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Character));
        using (FileStream stream = new FileStream(personSavePath+"Character.xml", FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    public override Person Load()
    {
        if (File.Exists(personSavePath + "Character.xml"))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Character));
            using (FileStream stream = new FileStream(personSavePath + "Character.xml", FileMode.Open))
            {
                return serializer.Deserialize(stream) as Character;
            }
        }
        return new Character();
    }

    public Character():base()
    {
        
    }
}
