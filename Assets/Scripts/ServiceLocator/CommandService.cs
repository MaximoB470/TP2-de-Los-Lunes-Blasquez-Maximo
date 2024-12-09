using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;
using UnityEngine.UI;

public class CommandService : MonoBehaviour
{
    [SerializeField] private List<Button> buttons;
    [SerializeField] private string commandToExecute;
    [SerializeField] private List<string> commandNames;
    [SerializeField] private List<Command> preloadedCommands;
    private Dictionary<string, ICommand> commandsDictionary = new Dictionary<string, ICommand>();
    void Start()
    {
        LoadAndRegisterCommands();
    }
    public void AddCommand(ICommand command)
    {
        if (!commandsDictionary.ContainsKey(command.Name))
        {
            commandsDictionary[command.Name] = command;
            foreach (var alias in command.Aliases)
            {
                if (!commandsDictionary.ContainsKey(alias))
                {
                    commandsDictionary[alias] = command;
                }
                else
                {
                    Debug.LogWarning($"Alias '{alias}' Was Up");
                }
            }
        }
    }
    private void LoadAndRegisterCommands()
    {
        Command[] commands = Resources.LoadAll<Command>("Commands");

        foreach (var command in commands)
        {
            AddCommand(command);
        }
    }
    private void SetupButtons()
    {
        if (buttons.Count != commandNames.Count)
        {
            return;
        }
        for (int i = 0; i < buttons.Count; i++)
        {
            string commandName = commandNames[i];
            if (commandsDictionary.ContainsKey(commandName))
            {
                buttons[i].onClick.AddListener(() => ExecuteCommand(commandName));
            }
        }
    }
    [ContextMenu("Execute Command")]
    private void ExecuteCommandFromInspector()
    {
        ExecuteCommand(commandToExecute);
    }
    public void ExecuteCommand(string name, string[] args = null)
    {
        if (commandsDictionary.TryGetValue(name, out ICommand command))
        {
            if (args == null || args.Length == 0)
            {
                command.Execute();
            }
            else
            {
                command.Execute(args);
            }

            Debug.Log($"Command '{name}' Executed");
        }
        else
        {
            Debug.LogWarning($"Command '{name}' Not Found");
        }
    }
}