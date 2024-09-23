using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MelkevekGames
{
    public class GenericCardSO : ScriptableObject
    {
        public string cardName;
        public int cardID;
        public Sprite cardSprite;
        public CardType cardType;
        public enum CardType{ None, Enemy, Zone, Resource, Aventurer, Equipment}
    }
}