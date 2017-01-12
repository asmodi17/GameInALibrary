using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInABox
{
    /// <summary>
    /// A Stat is a primary characteristic of a Character, and is used by skills
    /// </summary>
    class Stat
    {
        private String name;
        private int value;

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

        public int Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }
    }
}
