using ChestSystem.genericSingleton;
using System.Collections;
using System.Collections.Generic;
using ChestSystem.PoolObject;
using ChestSystem.ScriptableObjects;
using ChestSystem.Event;
using UnityEngine;

namespace ChestSystem.chest
{
    public class ChestService : GenericMonoSingleTon<ChestService>
    {
       private ChestObjectPool commonChestPoolObject;
        private ChestObjectPool rareChestPoolObject;
        private ChestObjectPool epicChestPoolObject;
        private ChestObjectPool legendaryChestPoolObeject;

        private Queue<ChestController> chestQueue = new();
        private List<ChestController> chestControllers = new();
        private bool chestUnlockingProcess;

        [SerializeField] private int numberOFSlot = 6;
        [SerializeField] private int chestQueueLenghth = 4;
        [SerializeField] private ScriptableOblectList chestScriptableobject;

        protected override void Awake()
        {
            base.Awake();
            commonChestPoolObject = new ChestObjectPool(chestScriptableobject.chests[0]);
            rareChestPoolObject = new ChestObjectPool(chestScriptableobject.chests[1]);
            epicChestPoolObject = new ChestObjectPool(chestScriptableobject.chests[2]);
            legendaryChestPoolObeject = new ChestObjectPool(chestScriptableobject.chests[3]);

        }
        private void Start()
        {
            EventService.instance.onCreateChest += CreateRandomChest;
        }
        private void CreateRandomChest(Transform chestHolder)
        {
            if(chestControllers.Count == numberOFSlot || chestHolder == null)
            {
                EventService.instance.InvokeOnSlotAreFull();
                return;
            }
            CreateChest((ChestType)Random.Range(0, chestScriptableobject.chests.Length), chestHolder);
        }
        private void CreateChest(ChestType chestType, Transform ChestHolder)
        {
            ChestScriptableObject chestData = chestScriptableobject.chests[(int)chestType];
            ChestController newchestController = null;
            switch(chestType)
            {
                case ChestType.Common:
                    newchestController = commonChestPoolObject.GetItem();
                    break;
                case ChestType.Rare:
                    newchestController = rareChestPoolObject.GetItem();
                    break;
                case ChestType.Epic:
                    newchestController = epicChestPoolObject.GetItem();
                    break;
                case ChestType.Legendary:
                    newchestController = legendaryChestPoolObeject.GetItem();
                    break;
            }
            newchestController.EnableChest(ChestHolder);
            chestControllers.Add(newchestController);
        }
        public void DestroyChest(ChestController chestController, ChestType chestType)
        {
            switch(chestType)
            {
                case ChestType.Common:
                    commonChestPoolObject.ReturnItem(chestController);
                    break;
                case ChestType.Rare:
                    commonChestPoolObject.ReturnItem(chestController);
                    break;
                case ChestType.Epic:
                    commonChestPoolObject.ReturnItem(chestController);
                    break;
                case ChestType.Legendary:
                    legendaryChestPoolObeject.ReturnItem(chestController);
                    break;
            }
            chestControllers.Remove(chestController);
            chestController.DisableChest();
        }
        public bool GetChestUnlockProcess()
        {
            return chestUnlockingProcess;
        }
        public void SetUnlockProcess(bool isUnlocking)
        {
            chestUnlockingProcess = isUnlocking;
        }
        public bool checkIfQueueIsFull()
        {
            return chestQueue.Count == chestQueueLenghth;
        }
        public void AddchestToQueue(ChestController chestController)
        {
            if(chestQueue.Count < chestQueueLenghth)
            {
                chestQueue.Enqueue(chestController);
            }
        }
        public bool CheckIfChestAlreadyInQueue(ChestController chestController)
        {
            return chestQueue.Contains(chestController);
        }
        public void OpenNextChestInQueue()
        {
            if(chestQueue.Count == 0)
            {
                return;
            }
            ChestController chestController = chestQueue.Dequeue();
            chestController.ChangeChestStateToUnlocking();
        }

        private void OnDestroy()
        {
            EventService.instance.onCreateChest -= CreateRandomChest;
            EventService.instance.onOpenNextChestInQueue -= OpenNextChestInQueue;
        }

    }


}

