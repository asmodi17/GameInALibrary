using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInABox
{
    class Character : GameItem
    {
        public Character()
            : base()
        {
            Type = GameItemType.Character;
        }
    }
}
