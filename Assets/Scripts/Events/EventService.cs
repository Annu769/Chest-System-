using System;
using UnityEngine;
namespace ChestSystem.Event
{
    public class EventService 
    {
        private static EventService Instance;
        public static EventService instance
        {
            get
            {
                if (Instance == null)
                    Instance = new EventService();
                return Instance;
            }
        }

        //Events

        public event Action<Transform> onCreateChest;
        public event Action<int> onUpdateCoinCount;
        public event Action<int> onUpdateGemCount;
        public event Action<int> onCheckConfirmGemUnlocked;
        public event Action<int, string> onCheckConfirmUnlocked;
        public event Action<int, int> onRewardRecieved;
        public event Action onConfirmUnlocked;
        public event Action onDenyUnlock;
        public event Action onRewardAccepted;
        public event Action onErrorAlReadyUnlocking;
        public event Action onUnlockWithTimer;
        public event Action onUnlockWithGem;
        public event Action onOpenNextChestInQueue;
        public event Action onChestQueueEmpty;
        public event Action<string> onOkayPopup;

        public void InvokeOnCreateChest(Transform chestHolder)
        {
            onCreateChest?.Invoke(chestHolder);
        }
        public void InvokeOnUpdateCoinCount(int coinCount)
        {
            onUpdateCoinCount?.Invoke(coinCount);
        }
        public void InvokeOnUpdateGemCount(int gemCount)
        {
            onUpdateGemCount?.Invoke(gemCount);
        }
        public void InvokeOnCheckConfirmUnlock(int GenCount, string time)
        {
            onCheckConfirmUnlocked?.Invoke(GenCount, time);

        }
        public void InvokeOnCheckConfirmGemUnlock(int gemCount)
        {
            onCheckConfirmGemUnlocked?.Invoke(gemCount);
        }
        public void InvokeOnConfirmUnlock()
        {
            onConfirmUnlocked?.Invoke();
        }
        public void InvokeOnDenyUnlock()
        {
            onDenyUnlock?.Invoke();
        }
        public void InvokeOnInsufficientGem()
        {
            onOkayPopup?.Invoke("Insufficient Gem!");
        }
        public void InvokeOnRewardRecived(int coinCount, int gemCount)
        {
            onRewardRecieved?.Invoke(coinCount, gemCount);
        }
        public void InvokeOnRewardAccepted()
        {
            onRewardAccepted?.Invoke();
        }
        public void InvokeOnErrorAlreadyUnlocking()
        {
            onErrorAlReadyUnlocking?.Invoke();
        }
        public void InvokeOnUnlockWithGem()
        {
            onUnlockWithGem?.Invoke();
        }
        public void InvokeOnUnlockWithTimer()
        {
            onUnlockWithTimer.Invoke();

        }
        public void InvokeOnSlotAreFull()
        {
            onOkayPopup.Invoke("Slot Are Full!!!");
        }
        public void InvokeOnOpenNextChestInQueue()
        {
            onOpenNextChestInQueue?.Invoke();
        }
        public void  InvokeOnChestQueueFull()
        {
            onOkayPopup?.Invoke("Queue Is Full !");
        }
        public void InvokeOnQueueContainsChest()
        {
            onOkayPopup?.Invoke("Chest Already in Queue !!");
        }
        public void InvokeOnChestQueueEmpty()
        {
            onChestQueueEmpty?.Invoke();
        }
        public void InvokeOnOkayPopUp(string text)
        {
            onOkayPopup?.Invoke(text);
        }
    }

}
