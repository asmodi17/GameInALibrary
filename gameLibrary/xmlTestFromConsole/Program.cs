using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gameLibrary;
using System.Xml;

namespace xmlTestFromConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Skill sword = new Skill();
            sword.Name = "Sword";
            sword.Stats.Add("Strength");
            sword.Stats.Add("Dexterity");
            sword.Types.Add(SkillType.Combat);

            XmlReader reader = XmlReader.Create("C:\\users\\asmod\\desktop\\skillWriteTest.xml");
            Skill test = new Skill();
            test.ReadXml(reader);
            return;
            /*
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            XmlWriter writer = XmlWriter.Create("C:\\users\\asmod\\desktop\\skillWriteTest.xml", settings);
            writer.WriteStartDocument();
            sword.WriteXml(writer);
            writer.WriteEndDocument();
            writer.Close(); */

        }
    }
}
