using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using GameInABox;

namespace XMLTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> stats = new List<string>();
            List<String> opposingSkills = new List<string>();
            Dictionary<String, String> interactions = new Dictionary<string, string>();
            stats.Add("Strength");
            stats.Add("Intelligence");
            opposingSkills.Add("Parry");
            opposingSkills.Add("Block");
            opposingSkills.Add("Dodge");
            interactions["CombatFormula"] = "(Strength + Intelligence) * Rank = (Parry + Block + Dodge) / 3";

            Skill s = new Skill("Sword", ref stats, ref opposingSkills, ref interactions);
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            Skill newSword = new Skill();
            XmlReader reader = XmlReader.Create("C:\\users\\phillip\\desktop\\skilltest.xml");
            newSword.ReadXml(reader);
            reader.Close();

            Console.ReadLine();

            XmlWriter writer = XmlWriter.Create("C:\\users\\phillip\\desktop\\skillWriteTest.xml", settings);
            writer.WriteStartDocument();
            s.WriteXml(writer);
            writer.WriteEndDocument();
            writer.Close();

            writer = XmlWriter.Create("C:\\users\\phillip\\desktop\\skillReadTest.xml", settings);
            writer.WriteStartDocument();
            newSword.WriteXml(writer);
            writer.WriteEndDocument();
            writer.Close();
        }
    }
}
