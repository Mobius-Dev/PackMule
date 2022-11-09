using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;

public class Console : MonoBehaviour
{
    [SerializeField] private bool _clearOnStart;
    [SerializeField] private TextMeshProUGUI _output;
    [SerializeField] private TMP_InputField _input;
    [SerializeField] private List<Command> _commands;

    private bool _isActive;
    private string _lastOutput;
    private string _lastInput;

    private void Start()
    {
        if (_clearOnStart) _output.text = "";
    }

    private void Update()
    {
        if (_isActive && Input.GetKeyDown(KeyCode.Return)) ParseInput();

        if (Input.GetKeyDown(KeyCode.UpArrow)) PasteLastCommand();
    }

    private void ParseInput()
    {
        string text = _input.text.ToLower();

        string[] args = text.Split(' '); //0th arg is command literal

        Command command = _commands.Where(x => x.Literal == args[0]).FirstOrDefault();

        if (command) ExecuteCommand(command.name, args);
        else Output(text + " is not a recognized command");

        _input.Select();
        _input.ActivateInputField();
        _lastInput = _input.text;
        _input.text = "";
    }

    private void ExecuteCommand(string name, string[] args)
    {
        Type console = this.GetType();
        MethodInfo commandMethod = console.GetMethod(name, BindingFlags.NonPublic | BindingFlags.Instance);
        object[] parameters = { args };
        commandMethod.Invoke(this, parameters);
    }

    private void Output(string text, bool dontOverwrite = false)
    {
        if (!dontOverwrite) _lastOutput = text;
        _output.text += "\n " + text;
    }

    private void PasteLastCommand()
    {
        _input.text = _lastInput;
        _input.MoveToEndOfLine(false, true);
    }

    public void OnInputSelected() => _isActive = true;

    public void OnInputDeselected() => _isActive = false;

    public void CopyLastOutput()
    {
        GUIUtility.systemCopyBuffer = _lastOutput;
        Output("Copied last output to clipboard", true);
    }

    #region Commands

    private void Ping(string[] args)
    {
        Output("Pong");
    }

    private void Clear(string[] args)
    {
        _output.text = "";
        Output("Clearing the console");
    }

    private void GetItem(string[] args)
    {
        if (args.Length < 3)
        {
            Output("GetItem: Too few parameters given");
            return;
        }

        Item item = LootManager.Instance.GetItemByName(args[1], args[2]);
        if (item != default) Output(item.DataTostring(true));
        else Output("GetItem: item '" + args[2] + "' was not found in '" + args[1] + "'");
    }

    private void GetLoot(string[] args)
    {
        if (args.Length < 3)
        {
            Output("GetItem: Too few parameters given");
            return;
        }

        //Mandatory arguments handling
        string poolName = args[1];
        float goldAvailable = float.Parse(args[2]);
        float minValueMultplier = 0f;

        //Optional argument handling
        if (args.Length >= 4)
        {
            minValueMultplier = float.Parse(args[3]);
        }
        bool shortMode = false;
        if (args.Length >= 5)
        {
            string flag = args[4];

            if (flag == "-s") //to-do put some static strings in
            {
                shortMode = true;
            }
        }

        List<Loot> lootList = new List<Loot>();
        List<Item> itemList = LootManager.Instance.GetLootByName(poolName, goldAvailable, minValueMultplier);
        if (itemList == default)
        {
            Output("GetLoot: Wrong pool name, OR there are no valid items in this pool");
            return;
        }

        foreach (Item item in itemList)
        {
            Loot loot = lootList.Where(x => x.Item == item).FirstOrDefault();
            if (loot == default)
            {
                lootList.Add(new Loot(item, 1));
            }
            else
            {
                loot.Quantity += 1;
            }
            goldAvailable -= item.Value;
        }

        string message = "";
        foreach (Loot loot in lootList)
        {
            message += loot.Quantity + "x " + loot.Item.DataTostring() + ", ";
            if (!shortMode) message += "\n";
        }
        message += "Z³oto " + (int)goldAvailable + "gp";
        Output(message);
    }

    #endregion Commands
}