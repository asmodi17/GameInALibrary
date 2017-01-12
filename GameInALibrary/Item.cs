using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInABox
{
    class Item : GameItem
    {
        public Item()
            : base()
        {
            Type = GameItemType.Item;
        }
    }
}
