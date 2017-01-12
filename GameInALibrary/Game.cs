using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GameInABox
{
    /// <summary>
    /// A Game is a definition for how a set of skills and stats interact with each other.
    /// Spepublic cifically, it defines Stats and Skills, and possibly other things as well.
    /// </summary>
    class Game : IXmlSerializable
    {
        public Game()
        {
        }

        private List<String> stats;
        private Dictionary<String, Skill> skills;

        public List<string> Stats
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

        public Dictionary<string, Skill> Skills
        {
            get
            {
                return skills;
            }

            private set
            {
                skills = value;
            }
        }

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
