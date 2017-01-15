using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Xml.Serialization;

public abstract class Person{
    [XmlArray("Skills"),XmlArrayItem("Skill")]
    public List<Skill> Skills;

    protected readonly string personSavePath = Path.Combine(Application.dataPath, "Resources/Xml/");
    public struct Skill
    {
        [XmlAttribute("KeyName")]
        public string KeyName { get; set; }
        [XmlElement("Level")]
        public int Level { get;  set; }
        [XmlElement("Progress")]
        public int Progress { get; set; }

        public Skill(string keyName, int level=0, int progress=0) : this()
        {
            this.KeyName = keyName;
            this.Level = level;
            this.Progress = progress;
        }
    }
	public virtual string Name
	{
		get;
		set;
	}
    // Use this for initialization
    protected virtual void Start () {

    }

    protected abstract void Save();
    public abstract Person Load();
    protected Person()
    {
        Skills= new List<Skill>();
        Skills.Add(new Skill("AbilityToPushAPIWithLessPrestige"));
        Skills.Add(new Skill("Charisma"));
        Skills.Add(new Skill("ErrorCorrection"));
        Skills.Add(new Skill("ExperienceGainRate"));
        Skills.Add(new Skill("LogicalOptimization"));
        Skills.Add(new Skill("PhysicalOptimization"));
        Skills.Add(new Skill("PrestigeGainRate"));
        Skills.Add(new Skill("RDPointGainRate"));
        Skills.Add(new Skill("Teamwork"));
    }
}
