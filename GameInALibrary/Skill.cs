using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GameInABox
{
    /// <summary>
    /// A Skill is a way to perform an action, or actions, and is closely tied to stats
    /// </summary>
    public class Skill : IXmlSerializable
    {
        public Skill()
        {
            Stats = new List<string>();
            OpposingSkills = new List<string>();
            Interactions = new Dictionary<string, string>();
        }

        public Skill(String name, ref List<String> stats, ref List<String> opposingSkills, ref Dictionary<String, String> interactions)
        {
            Name = name;
            Stats = stats;
            OpposingSkills = opposingSkills;
            Interactions = interactions;
        }

        public const String skillString = "Skill";
        public const String statsString = "Stats";
        public const String opposingSkillsString = "OpposingSkills";
        public const String nameString = "Name";
        public const String InteractionString = "Interactions";

        private string name;
        private List<String> stats;
        private List<String> opposingSkills;
        private Dictionary<String, String> interactions;

        public string Name
        {
            get
            {
                return name;
            }

            private set
            {
                name = value;
            }
        }

        public List<String> Stats
        {
            get
            {
                return stats;
            }

            private set
            {
                stats = value;
            }
        }

        public List<string> OpposingSkills
        {
            get
            {
                return opposingSkills;
            }

            private set
            {
                opposingSkills = value;
            }
        }

        public Dictionary<string, string> Interactions
        {
            get
            {
                return interactions;
            }

            set
            {
                interactions = value;
            }
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            bool addToStats = false;
            bool addToOpposingSkills = false;
            bool getBaseAttributes = false;
            while (reader.Read())
            {
                if (String.IsNullOrEmpty(reader.Name))
                {
                    // Ignore newlines.
                    continue;
                }

                if (reader.Name == skillString)
                {
                    // Only read until the Skill is complete.
                    if (!reader.IsStartElement()) break; 
                    getBaseAttributes = true;
                }

                if (reader.HasAttributes && getBaseAttributes)
                {
                    // Eventually, other elements might have attributes as well.
                    Name = reader.GetAttribute(nameString);
                    getBaseAttributes = false;
                }

                if (reader.IsStartElement())
                {
                    if (reader.Name == statsString)
                    {
                        if (!addToStats)
                        {
                            // Start of the Stats collection
                            addToStats = true;
                        }
                    }
                    else if (reader.Name == opposingSkillsString)
                    {
                        if (!addToOpposingSkills)
                        {
                            // Start of the OpposingSkills collection
                            addToOpposingSkills = true;
                        }
                    }
                    else if (reader.IsEmptyElement)
                    {
                        // An empty element means that it is an element with no value
                        // Must be a child element
                        if (addToStats)
                        {
                            // Stat element
                            Stats.Add(reader.Name);
                        }
                        else if (addToOpposingSkills)
                        {
                            // 
                            OpposingSkills.Add(reader.Name);
                        }
                    }
                }
                else // Not a Start Element, must be the end of something.
                {
                    if (!reader.IsEmptyElement)
                    {
                        if (addToStats)
                        {
                            // End Stats
                            addToStats = false;
                        }
                        if (addToOpposingSkills)
                        {
                            // End OpposingSkills
                            addToOpposingSkills = false;
                        }
                    }
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement(skillString);
            writer.WriteAttributeString(nameString, Name);
            writer.WriteStartElement(statsString);
            foreach (String s in Stats)
            {
                writer.WriteStartElement(s);
                writer.WriteEndElement();
            }
            writer.WriteEndElement(); // Stats
            writer.WriteStartElement(opposingSkillsString);
            foreach (String s in OpposingSkills)
            {
                writer.WriteStartElement(s);
                writer.WriteEndElement();
            }
            writer.WriteEndElement(); // OpposingSkills
            writer.WriteEndElement(); // Skill
        }
    }
}
