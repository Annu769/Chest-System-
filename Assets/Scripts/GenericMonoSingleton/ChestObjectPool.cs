using System.Collections;
using System.Collections.Generic;
using ChestSystem.ScriptableObjects;
using ChestSystem.chest;
using UnityEngine;
namespace ChestSystem.PoolObject
{
    public class ChestObjectPool : MonoBehaviour
    {
        private ChestScriptableObject chestData;
        List<PoolItem> itemPool = new();

        public ChestObjectPool(ChestScriptableObject _chestData) => chestData = _chestData;

        public ChestController GetItem()
        {
            if(itemPool.Count == 0)
            {
                return CreatePoolItem().item;
            }
            PoolItem poolItem = itemPool.Find(newItem => newItem.isUsed == false);
            if(poolItem != null)
            {
                poolItem.isUsed = true;
                return poolItem.item;
            }
            return CreatePoolItem().item;
        }
        private PoolItem CreatePoolItem()
        {
            PoolItem newPoolitem = new PoolItem();
            newPoolitem.item = CreateItem();
            newPoolitem.isUsed = true;
            itemPool.Add(newPoolitem);
            return newPoolitem;
        }

        private ChestController CreateItem()
        {
            ChestController chestController = new ChestController(chestData);
            return chestController;

        }

        public void ReturnItem(ChestController chestController)
        {
            PoolItem poolItem = itemPool.Find(newItem => newItem.item == chestController);
            if(poolItem == null)
            {
                poolItem.isUsed = false;
            }
        }
    }
    public class PoolItem
    {
        public ChestController item;
        public bool isUsed;
    }

}
