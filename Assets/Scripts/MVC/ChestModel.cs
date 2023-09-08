using ChestSystem.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ChestSystem.chest
{
    public class ChestModel
    {
        private ChestController chestController;
        public ChestType chestType { get; }
        public int minCoin { get; }
        public int maxCoin { get; }
        public int minGems { get; }
        public int maxGems { get; }
        public float timeToOpen { get; }

        public ChestModel(ChestScriptableObject chestScriptable)
        {
            chestType = chestScriptable.Chests;
            minCoin = chestScriptable.MinCoin;
            maxCoin = chestScriptable.MaxCoin;
            minGems = chestScriptable.MinGems;
            maxGems = chestScriptable.MaxGems;
            timeToOpen = chestScriptable.TimeToOpenChest;

        }

        public void SetChestController(ChestController _chestController)
        {
            chestController = _chestController;
        }


    }

}
