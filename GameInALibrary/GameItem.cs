using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInABox
{
    public enum GameItemType
    {
        Character,
        Item,
        Location
    }

    public abstract class GameItem
    {
        private GameItemType type;

        public GameItemType Type
        {
            get
            {
                return type;
            }

            protected set
            {
                type = value;
            }
        }
    }
}
