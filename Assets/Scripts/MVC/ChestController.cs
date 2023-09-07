using ChestSystem.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ChestSystem.chest
{
    public class ChestController
    {
        private ChestModel chestModel;
        private ChestView chestView;

        public ChestController(ChestScriptableObject chestConfiguration)
        {
            chestModel = new ChestModel(chestConfiguration);
            chestView = GameObject.Instantiate<ChestView>(chestConfiguration.ChestView);
            chestView.transform.position = Vector3.zero;

            chestModel.SetChestController(this);
            chestView.SetChestController(this);
        }
        private void SetChestParent(Transform parent)
        {
            chestView.transform.SetParent(parent, false);
        }
        public void ChestOpened()
        {
            ChestService.instance.DestroyChest(this, chestModel.chestType);
        }

        public float GetTimeToOpneChest()
        {
           return chestModel.timeToOpen;
        }
        public void EnableChest(Transform parent)
        {
            SetChestParent(parent);
            chestView.gameObject.SetActive(true);
        }

        public void DisableChest()
        {
            SetChestParent(null);
            chestView.gameObject.SetActive(false);
        }
       public void  ChangeChestStateToUnlocking()
        {
            
        }
        public bool GetChestUnlockProcess()
        {
            return ChestService.instance.GetChestUnlockProcess();
        }
        public void SetChestUnlockProcess(bool isUnlocking)
        {
            ChestService.instance.SetUnlockProcess(isUnlocking);
        }
        public void AddChestToQueue()
        {
            ChestService.instance.AddchestToQueue(this);
        }
        public bool CheckIfChestAlreadyInQueue()
        {
            return ChestService.instance.CheckIfChestAlreadyInQueue(this);
        }
        public bool CheckIfQueueIsFull()
        {
            return ChestService.instance.checkIfQueueIsFull();
        }
    }

}
