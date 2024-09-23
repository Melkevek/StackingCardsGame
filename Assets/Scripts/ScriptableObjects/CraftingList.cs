using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MelkevekGames
{
    [CreateAssetMenu(fileName = "Resource", menuName = "Scriptable obj/CraftingList", order = 0)]

    public class CraftingList : ScriptableObject
    {
        public List<int> iDResultList = new List<int>();
        public List<GameObject> cardList = new List<GameObject>();
    }
}
