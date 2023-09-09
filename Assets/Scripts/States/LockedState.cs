using System;
using System.Collections;
using System.Collections.Generic;
using ChestSystem.Event;

using ChestSystem.Currency;

using UnityEngine;
namespace ChestSystem.chest
{
    public class LockedState : State
    {
        private GameObject LockedPanel;
        private float timeToUnlock;
        private string timer;
        private int gemCost;

        protected override void Awake()
        {
            base.Awake();
            LockedPanel = chestView.GetLockedPanel();
        }
        private void Start()
        {
            timeToUnlock = chestView.GetTimeToOpenChest();
            SetTimeString();
            SetGemCount();
        }

        private void SetGemCount()
        {
            float hours = Mathf.FloorToInt(timeToUnlock / 3600);
            float minutes = Mathf.FloorToInt(timeToUnlock / 60);
            float seconds = Mathf.FloorToInt(timeToUnlock % 60);
            timer = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        }

        private void SetTimeString()
        {
            float minutes = Mathf.FloorToInt((timeToUnlock + 1) / 60);
            gemCost = Mathf.CeilToInt(minutes / 10);
            if(gemCost == 0 )
            {
                gemCost = 1;
            }
        }
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            LockedPanel.SetActive(true);
        }
        public override void OnStateExit()
        {
            base.OnStateExit();
            LockedPanel.SetActive(false);
        }

        private void UnlockChest()
        {
            EventService.instance.InvokeOnCheckConfirmUnlock(gemCost, timer);

            EventService.instance.onUnlockWithGem += GemsBaseedUnlocked;
            EventService.instance.onUnlockWithTimer += TimerBasedUnlocked;
        }

        private void GemsBaseedUnlocked()
        {
            EventService.instance.onUnlockWithTimer -= TimerBasedUnlocked;
            EventService.instance.onUnlockWithGem -= GemsBaseedUnlocked;

            if (CurrencyService.instance.RemoveGems(gemCost))
                chestView.ChangeChestState(chestView.chestOpenedState);
            else
                EventService.instance.InvokeOnInsufficientGem();

        }

        private void TimerBasedUnlocked()
        {
            EventService.instance.onUnlockWithGem -= GemsBaseedUnlocked;
            EventService.instance.onUnlockWithTimer -= TimerBasedUnlocked;
            chestView.ChangeChestState(chestView.chestUnlockingState);
        }
        public override void OnChestClick()
        {
            base.OnChestClick();

            if(!chestView.GetChestUnlockingProcess())
            {
                UnlockChest();
            }
            else if(chestView.CheckIfChestAlreadyInQueue())
            {
                EventService.instance.InvokeOnQueueContainsChest();
            }
            else if(chestView.CheckIfQueueIsFull())
            {
                EventService.instance.InvokeOnChestQueueFull();
            }
            else
            {
                chestView.EnableQueueText();
                chestView.AddChestToQueue();
            }
        }

    }
}

