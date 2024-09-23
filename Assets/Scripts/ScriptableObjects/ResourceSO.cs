using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MelkevekGames
{
    [CreateAssetMenu(fileName = "Resource", menuName = "Scriptable obj/Resource", order = 2)]

    public class ResourceSO : GenericCardSO
    {
        public int value;
        public ResourceType resourceType;
        public enum ResourceType { None, Crafting, CookedFood, RawFood, HealthPotion, Antidote, Animal}
    }
}
