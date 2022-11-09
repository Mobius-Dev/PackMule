using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 2)]
public class Item : ScriptableObject
{
    public string Name => _name;
    public string Description => _description;
    public EItemType Type => _type;
    public float Value => _value;
    public float Weight => _weight;

    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private EItemType _type;
    [SerializeField] private float _value; //In gold pieces to-do other currencies
    [SerializeField] private float _weight; //In pounds

    public string DataTostring(bool inclDescription = false)
    {
        string data = _name + "|" + _value + "gp|" + _weight + "pnd|"; // + _description;
        if (inclDescription) data += _description;
        return data;
    }
}