using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ChestSystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ChestScriptableObjet", menuName = "ChestScriptableObject/ NewChest")]
    public class ChestScriptableObject : ScriptableObject
    {
        [SerializeField]
        [Header("TYPE OF CHESTS")]
        private ChestType chestType;


        [Header("COINS")]
        [SerializeField]
        private int minCoin;
        [SerializeField]
        private int maxCoin;


        [Header("GEMS")]
        [SerializeField]
        private int minGems;
        [SerializeField]
        private int maxGems;


        [Header("CHEST TIMER")]
        [SerializeField]
        private float timeToOpenChest;

        [Header("CHESTVIEW")]
        [SerializeField]
        private ChestView chestView;


        public ChestType Chests { get => chestType; set => chestType = value; }
        public int MinCoin { get => minCoin; set => minCoin = value; }
        public int MaxCoin { get => maxCoin; set => maxCoin = value; }
        public int MinGems { get => minGems; set => minGems = value; }
        public int MaxGems { get => maxGems; set => maxGems = value; }
        public float TimeToOpenChest { get => timeToOpenChest; set => timeToOpenChest = value; }
        public ChestView ChestView { get => chestView; set => chestView = value; }
    }
}
