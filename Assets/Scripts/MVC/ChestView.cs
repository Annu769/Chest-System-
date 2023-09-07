using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace ChestSystem.chest
{
    public class ChestView : MonoBehaviour
    {
        ChestController chestController;
        [SerializeField] private Image imageHolder;
        [SerializeField] private ChestType chestType;
        [SerializeField] private Sprite chestClosedImage;
        [SerializeField] private Sprite ChestOpenedImage;

        [Header("State Serialize Fields")]
        [SerializeField] private GameObject lockedPanel;
        [SerializeField] private GameObject inQueueText;
        [SerializeField] private GameObject unlokingPanel;
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private TMP_Text gemCountText;
        [SerializeField] private GameObject chestOpenedPanel;

        private void Start()
        {
            imageHolder.sprite = chestClosedImage;
        }
        public void SetChestController(ChestController _chestController)
        {
            chestController = _chestController;
        }
        public GameObject GetLockedPanel()
        {
            return lockedPanel;
        }
        public GameObject GetUnlockedPanel()
        {
            return unlokingPanel;
        }
        public GameObject GetOpendPanel()
        {
            return chestOpenedPanel;
        }
        public Image GetImageHolder()
        {
            return imageHolder;
        }
        public Sprite GetChestClosedImage()
        {
            return chestClosedImage;
        }
        public Sprite GetChestOpenedImage()
        {
            return ChestOpenedImage;
        }
        public TMP_Text GetTimerText()
        {
            return timerText;
        }
        public TMP_Text GetGemCountText()
        {
            return gemCountText;
        }
        public float GetTimeToOpenChest()
        {
            return chestController.GetTimeToOpneChest();
        }
        public void ChestCollected()
        {
            chestController.ChestOpened();
        }
        public bool GetChestUnlockingProcess()
        {
            return chestController.GetChestUnlockProcess();
        }

        public void SetChestUnlockingProcess(bool isUnlocking)
        {
            chestController.SetChestUnlockProcess(isUnlocking);
        }
        public void EnableQueueText()
        {
            inQueueText.SetActive(true);
        }
        public void DisableQueueText()
        {
            if (inQueueText.activeInHierarchy)
                inQueueText.SetActive(false);
        }

        public void AddChestToQueue()
        {
            chestController.AddChestToQueue();
        }
        public bool CheckIfChestAlreadyInQueue()
        {
            return chestController.CheckIfChestAlreadyInQueue();
        }
        public bool CheckIfQueueIsFull()
        {
            return chestController.CheckIfQueueIsFull();
        }
    }
}