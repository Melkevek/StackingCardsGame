using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MelkevekGames
{
    [CreateAssetMenu(fileName = "Aventurer", menuName = "Scriptable obj/Aventurer", order = 1)]
    public class AventurerSO : GenericCardSO
    {
        public int health;
        public int stamina;
        public int damage;
        public int initiave;
        public int defense;
        public int equipmentSlots;
        //public List<EquipmentSO> equipment;
        
        public Class classType;

        public enum Class { None, Novice, Aventurer, 
            MageApprentice, WarriorApprentice, RangerApprentice, ThiefApprentice,
            Mage, Warrior, Ranger, Thief,
            MageMaster,WarriorMaster,RangerMaster, ThiefMaster}

    }
}
