using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChestSystem.genericSingleton;
using ChestSystem.Event;
namespace ChestSystem.Currency
{
    public class CurrencyService :GenericMonoSingleTon<CurrencyService>
    {
        private int coin;
        private int gems;
        [SerializeField] private int basecoin = 5000;
        [SerializeField] private int baseGems = 10;

        private void Start()
        {
            coin = basecoin;
            gems = baseGems;
            EventService.instance.InvokeOnUpdateCoinCount(coin);
            EventService.instance.InvokeOnUpdateGemCount(gems);
        }

        public void AddCoin(int coinCount)
        {
            coin += coinCount;
            EventService.instance.InvokeOnUpdateGemCount(coin);
        }
        public bool RemoveCoin(int coinCount)
        {
            if(coin - coinCount < 0)
            {
                return false;
            }
            coin -= coinCount;
            EventService.instance.InvokeOnUpdateCoinCount(coin);
            return true;
        }
        public void  AddGems(int gemCount)
        {
            gems += gemCount;
            EventService.instance.InvokeOnUpdateGemCount(gems);
        }
        public bool RemoveGems(int gemCount)
        {
            if(gems - gemCount < 0)
            {
                return false;
            }
            gems -= gemCount;
            EventService.instance.InvokeOnUpdateGemCount(gems);
            return true;
        }
    }

}
