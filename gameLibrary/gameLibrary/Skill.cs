using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace gameLibrary
{
    /// <summary>
    /// A Skill can have multiple types.
    /// </summary>
    public enum SkillType
    {
        NonCombat,
        Combat,
        Attack,
        Defense
    }

    /// <summary>
    /// A Skill is a way to perform an action, or actions, and is closely tied to stats
    /// </summary>
    public class Skill : IXmlSerializable
    {
        public List<SkillType> Types;
        public List<string> Stats;
        public string Name;

        public Skill()
        {
            Types = new List<SkillType>();
            Stats = new List<string>();
            Name = "";
        }

        public string SkillTypeToString(SkillType val)
        {
            switch (val)
            {
                case SkillType.Attack: return "Attack";
                case SkillType.Combat: return "Combat";
                case SkillType.Defense: return "Defense";
                case SkillType.NonCombat: return "NonCombat";
                default: return "";
            }
        }

        public SkillType StringToSkillType(String val)
        {
            switch (val)
            {
                case "Attack": return SkillType.Attack;
                case "Combat": return SkillType.Combat;
                case "Defense": return SkillType.Defense;
                default: return SkillType.NonCombat;
            }
        }

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            bool finished = false;
            while (!finished && reader.Read())
            {
                //if (reader.IsEmptyElement) continue;
                //if (string.IsNullOrEmpty(reader.Name) && (!reader.HasValue || string.IsNullOrEmpty(reader.Value))) continue; // Ignore newlines
                string toPrint = string.Empty;
                if (reader.Value.Contains("\r") || reader.Value.Contains("\n")) continue;
                if (reader.Name == "Skill")
                {
                    if (!reader.IsStartElement())
                    {
                        finished = true;
                        continue;
                    }
                    else
                    {
                        if (reader.HasAttributes)
                        {
                            this.Name = reader.GetAttribute("Name");
                            // There could be more attributes later?
                        }
                    }
                }
                bool readStatValue = false;
                bool readTypeValue = false;
                if (reader.Name == "Stat")
                {
                    if (!reader.IsStartElement()) readStatValue = false;
                    else readStatValue = true; // If the skill had some specified stat ratio or something, the attribute would go here.
                }
                if (reader.Name == "Type")
                {
                    if (!reader.IsStartElement()) readTypeValue = false;
                    else readTypeValue = true;
                }
                if (readStatValue)
                {
                    this.Stats.Add(reader.Value);
                }
                if (readTypeValue)
                {
                    this.Types.Add(StringToSkillType(reader.Value));
                }
                toPrint += "Name: " + reader.Name;
                toPrint += ", LocalName: " + reader.LocalName;
                toPrint += ", Value: " + reader.Value;
                toPrint += ", isStartElement: " + reader.IsStartElement();
                if (reader.HasAttributes)
                {
                    for (int i=0; i < reader.AttributeCount; i++)
                    {
                        toPrint += ", Attribute: " + reader.GetAttribute(i);
                    }
                }
                Console.WriteLine(toPrint);
            }
            Console.ReadKey();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Skill");
            writer.WriteAttributeString("Name", Name);
            foreach (String s in Stats)
            {
                writer.WriteStartElement("Stat");
                writer.WriteString(s);
                writer.WriteEndElement();
            }
            foreach (SkillType s in Types)
            {
                writer.WriteStartElement("Type");
                writer.WriteString(SkillTypeToString(s));
                writer.WriteEndElement();
            }
            writer.WriteEndElement(); // Skill
        }
    }
}
