using ChestSystem.Event;
using UnityEngine;
using UnityEngine.UI;
namespace ChestSystem.chest
{
    public class OpenState :State
    {
        private int CoinReward;
        private int gemReward;
        private GameObject chestOpenedPanel;
        private Image imageHolder;
        private Sprite chestOpenedImage;
        protected override void Awake()
        {
            base.Awake();
            chestOpenedPanel = chestView.GetOpendPanel();
            imageHolder = chestView.GetImageHolder();
            chestOpenedImage = chestView.GetChestOpenedImage();
        }
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            EventService.instance.InvokeOnOpenNextChestInQueue();
            chestOpenedPanel.SetActive(true);
        }
        public override void OnChestClick()
        {
            base.OnChestClick();
            imageHolder.sprite = chestOpenedImage;
            chestOpenedPanel.SetActive(false);
            ChestModel chestReward = chestView.GetChestModel();
            CoinReward = Random.Range(chestReward.minCoin, chestReward.maxCoin + 1);
            gemReward = Random.Range(chestReward.minGems, chestReward.maxGems + 1);

            EventService.instance.InvokeOnRewardRecived(CoinReward, gemReward);
            EventService.instance.onRewardAccepted += CollectReward;
        }
        private void CollectReward()
        {
            EventService.instance.onRewardAccepted -= OnStateExit;
            EventService.instance.onRewardAccepted -= CollectReward;
            chestView.ChestCollected();
        }
        public override void OnStateExit()
        {
            base.OnStateExit();
        }
    }

}

