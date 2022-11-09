using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemPool", menuName = "ScriptableObjects/ItemPool", order = 3)]
public class ItemPool : ScriptableObject
{
    public string Name => _name;
    public List<Item> Content => _content;
    public List<ItemPool> SubPools => _subPools;

    [SerializeField] private string _name;
    [SerializeField] private List<Item> _content;
    [SerializeField] private List<ItemPool> _subPools;
}