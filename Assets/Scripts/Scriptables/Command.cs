using UnityEngine;

[CreateAssetMenu(fileName = "Command", menuName = "ScriptableObjects/Command", order = 1)]
public class Command : ScriptableObject
{
    public string Name => _name;
    public string Literal => _literal;

    [SerializeField] private string _name;
    [SerializeField] private string _literal;
    //int min arguments
    //int max arguments
    //flag[] valid flags
}