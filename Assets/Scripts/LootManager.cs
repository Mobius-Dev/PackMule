using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    [SerializeField] private bool _clearEmpty;

    [SerializeField] private List<ItemPool> _itemPools;

    public static LootManager Instance;

    private void Start()
    {
        Instance = this;

        if (_clearEmpty)
        {
            foreach (ItemPool pool in _itemPools)
            {
                pool.Content.RemoveAll(item => item == null);
            }
        }
    }

    private ItemPool FindPoolInList(string name)
    {
        ItemPool itemPool = _itemPools.Where(x => x.Name.ToLower() == name).FirstOrDefault();
        return itemPool;
    }

    private List<Item> ExpandEmbeddedPools(ItemPool pool)
    {
        if (pool.SubPools.Count == 0) return default;

        List<Item> itemsToAdd = new List<Item>();

        foreach (ItemPool subPool in pool.SubPools)
        {
            foreach (Item item in subPool.Content)
            {
                itemsToAdd.Add(item);
            }
        }
        return itemsToAdd;
    }

    public Item GetItemByName(string poolName, string itemName)
    {
        //To-Do remake this command somehow, to search some kind of 'master pool' by default

        ItemPool itemPool = FindPoolInList(poolName);
        if (!itemPool) return default;

        List<Item> itemsInPool = itemPool.Content;

        //Handle embedded pools, if any
        List<Item> itemsInSubPools = ExpandEmbeddedPools(itemPool);
        if (itemsInSubPools != default)
        {
            foreach (Item item in itemsInSubPools)
            {
                if (!itemsInPool.Contains(item)) itemsInPool.Add(item); //to-do test if this contains check works correctly
            }
        }

        return itemsInPool.Where(x => x.Name.ToLower() == itemName).FirstOrDefault();
    }

    public List<Item> GetLootByName(string poolName, float totalValue, float minValueMultiplier)
    {
        //Gets the pool mentioned in the command
        ItemPool itemPool = FindPoolInList(poolName);
        if (!itemPool) return default;

        //Handle main pool
        List<Item> itemsInPool = new List<Item>();
        foreach (Item item in itemPool.Content)
        {
            itemsInPool.Add(item);
        }

        //Handle embedded pools, if any
        List<Item> itemsInSubPools = ExpandEmbeddedPools(itemPool);
        if (itemsInSubPools != default)
        {
            foreach (Item item in itemsInSubPools)
            {
                if (!itemsInPool.Contains(item)) itemsInPool.Add(item); //to-do test if this contains check works correctly
            }
        }

        float lowestValue = float.MaxValue; //Determine lowest value in the pool
        foreach (Item item in itemsInPool)
        {
            if (item.Value < lowestValue) lowestValue = item.Value;
        }

        List<Item> lootList = new List<Item>(); //create a fresh list
        float cachedTotalValue = totalValue;
        while (totalValue >= lowestValue && totalValue >= cachedTotalValue * minValueMultiplier && itemsInPool.Count > 0)
        {
            itemsInPool = ShufflePool(itemsInPool); //Shuffle

            int i = Random.Range(0, itemsInPool.Count);
            if (itemsInPool[i].Value <= totalValue && itemsInPool[i].Value >= cachedTotalValue * minValueMultiplier) //Does item meet conditions?
            {
                lootList.Add(itemsInPool[i]);
                totalValue -= itemsInPool[i].Value;
            }
            else
            {
                itemsInPool.RemoveAt(i);
                itemsInPool.RemoveAll(item => item == null);
            }
        }

        if (lootList.Count == 0) return default;
        return lootList;
    }

    private List<Item> ShufflePool(List<Item> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Item temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }

        return list;
    }
}