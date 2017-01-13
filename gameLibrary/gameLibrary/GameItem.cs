namespace gameLibrary
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
