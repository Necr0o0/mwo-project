using UnityEngine;

public class CardData
{
    public string title;
    public string description;
    public Style style;

    public class Style
    {
        public Sprite background;
        public Sprite backSide;
    }
}