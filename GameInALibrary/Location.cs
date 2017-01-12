using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInABox
{
    /// <summary>
    /// A Location is an arbitrary box containing any number of characters and items.
    /// </summary>
    class Location : GameItem
    {
        public Location()
            : base()
        {
            Type = GameItemType.Location;
        }
    }
}
