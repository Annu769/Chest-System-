using System.Collections;
using ChestSystem.Event;
using TMPro;
using UnityEngine;
namespace ChestSystem.UI
{
    public class UIManager : MonoBehaviour
    {
        private Transform[] chestHolders;
        private Coroutine textFaceCoroutine;
        private bool coroutineRunning;

        [Header("CURRENCY")]
        [SerializeField] private TMP_Text coinCount;
        [SerializeField] private TMP_Text gemCoint;

        [Header("Chest Container")]
        [SerializeField] private Transform chestContainer;

        [Header("Confirm Unlock")]
        [SerializeField] private GameObject confirmUnlockPanel;
        [SerializeField] private TMP_Text gemCountText;
        [SerializeField] private TMP_Text TimerText;

        [Header("Confirm Unlock With Gems")]
        [SerializeField] private GameObject confirmUnlockWithGemPanel;
        [SerializeField] private TMP_Text UnlockWithGemsText;

        [Header("Reward PopUP")]
        [SerializeField] private GameObject rewardsPopUP;
        [SerializeField] private TMP_Text coinRewardCount;
        [SerializeField] private TMP_Text gemRewardCount;
        [Header("ERRORS")]
        [SerializeField] private CanvasGroup errorChestAlreadyOPen;

        [Header("Okay PopUP")]
        [SerializeField] private GameObject okayPopUp;
        [SerializeField] private TMP_Text okayText;

        private void Awake()
        {
            chestHolders = new Transform[chestContainer.childCount];
            for(int i = 0; i < chestContainer.childCount; i++)
            {
                chestHolders[i] = chestContainer.GetChild(i);
            }

            EventService.instance.onUpdateCoinCount += UpdateCoinCount;
            EventService.instance.onUpdateGemCount += UpdateGemCount;
            EventService.instance.onCheckConfirmGemUnlocked += UnlockWithGemPopUp;
            EventService.instance.onCheckConfirmUnlocked += UnlockChestPopUp;
            EventService.instance.onRewardRecieved += EnableRewardsPopUp;
            EventService.instance.onErrorAlReadyUnlocking += ChestAlreadyBeingOpened;
            EventService.instance.onOkayPopup += EnableOkayPopup;
        }

        public Transform GetChestHolder()
        {
            foreach(Transform item in chestHolders)
            {
                if (item.childCount == 0)
                    return item;
            }
            return null;
        }
        public void CreateChest()
        {
            Transform chestHolder = GetChestHolder();
            EventService.instance.InvokeOnCreateChest(chestHolder);
        }
        public void UpdateCoinCount(int cointCountValue)
        {
            coinCount.text = cointCountValue.ToString();
        }
        public void UpdateGemCount(int gemCountValue)
        {
            gemCoint.text = gemCountValue.ToString();
        }
        public void UnlockChestPopUp(int gemcount, string timer)
        {
            gemCountText.text = gemcount.ToString();
            TimerText.text = timer;
            confirmUnlockPanel.SetActive(true);
        }
        public void UnlockWithGemPopUp(int gemcount)
        {
            UnlockWithGemsText.text = "UNLOCK CHEST WITH" + gemcount + "gems?";
            confirmUnlockWithGemPanel.SetActive(true);
        }
        public void CloseUnlockPopUp()
        {
            confirmUnlockPanel.SetActive(false);
        }
        public void UnlockWithTimer()
        {
            EventService.instance.InvokeOnUnlockWithTimer();
            CloseUnlockPopUp();
        }
        public void UnlockWithGems()
        {
            EventService.instance.InvokeOnUnlockWithGem();
            CloseUnlockPopUp();
            
        }
        public void CloseUnlockChestWithGemsPopUp()
        {
            confirmUnlockWithGemPanel.SetActive(false);
        }
        public void EnableOkayPopup(string text)
        {
            okayText.text = text;
            okayPopUp.SetActive(true);
        }
        public void DisableOkayPopUp()
        {
            okayPopUp.SetActive(false);
        }
        public void ConfirmUnlock()
        {
            CloseUnlockChestWithGemsPopUp();
            EventService.instance.InvokeOnConfirmUnlock();
        }
        public void DenyUnlock()
        {
            CloseUnlockChestWithGemsPopUp();
            EventService.instance.InvokeOnDenyUnlock();
        }
        public void EnableRewardsPopUp(int coinCount,int gemCount)
        {
            coinRewardCount.text = coinCount.ToString();
            gemRewardCount.text = gemCount.ToString();
            rewardsPopUP.SetActive(true);
        }

        public void AcceptReward()
        {
            rewardsPopUP.SetActive(false);
            EventService.instance.InvokeOnRewardAccepted();
        }

        public void ChestAlreadyBeingOpened()
        {
            if(coroutineRunning)
            {
                StopCoroutine(textFaceCoroutine);
                coroutineRunning = false;
            }
            textFaceCoroutine = StartCoroutine(BeingFade());
        }
        private IEnumerator BeingFade()
        {
            errorChestAlreadyOPen.alpha = 1;
            coroutineRunning = true;
            yield return new WaitForSeconds(2f);

            while(errorChestAlreadyOPen.alpha > 0 )
            {
                errorChestAlreadyOPen.alpha -= 0.5f * Time.deltaTime;
                yield return null;
            }
            errorChestAlreadyOPen.alpha = 0;
            coroutineRunning = false;

        }
        private void OnDestroy()
        {
            EventService.instance.onUpdateCoinCount += UpdateCoinCount;
            EventService.instance.onUpdateGemCount += UpdateGemCount;
            EventService.instance.onCheckConfirmGemUnlocked += UnlockWithGemPopUp;
            EventService.instance.onCheckConfirmUnlocked += UnlockChestPopUp;
            EventService.instance.onRewardRecieved += EnableRewardsPopUp;
            EventService.instance.onErrorAlReadyUnlocking += ChestAlreadyBeingOpened;
            EventService.instance.onOkayPopup += EnableOkayPopup;
        }
    }

}
