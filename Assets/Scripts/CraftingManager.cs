using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MelkevekGames
{
    public class CraftingManager : MonoBehaviour
    {
        [SerializeField] private CraftingList craftingList;
        public BoardController boardController;

        public void CheckResult(int result)
        {
            for (int i = 0; i < craftingList.iDResultList.Count; i++)
            {
                if (result == craftingList.iDResultList[i])
                {
                    Debug.Log("Ladrillo");
                }
            }
        }
    }
}
