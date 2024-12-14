using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandButton : MonoBehaviour
{
    [SerializeField] private string commandAlias; 
    private string arguments;
    public void OnClick()
    {
        var commandConsoleService = ServiceLocator.Instance.GetService<CommandConsoleService>();

        if (commandConsoleService != null)
        {
            string[] args = string.IsNullOrWhiteSpace(arguments) ? new string[0] : arguments.Split(' ');
            commandConsoleService.ExecuteCommand(commandAlias, args);
        }
    }
    public void OnButtonClick()
    {
        OnClick();
    }
}