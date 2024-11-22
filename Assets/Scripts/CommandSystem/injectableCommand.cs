using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class injectableCommand : Icommand
{
    public string Name { get; set; }

    public List<string> Aliases { get; set; }

    //Summarises List (to remember)

    //private List<string> Aaliases;

    //public List <string> GetAliases() 
    //{
    //    return Aaliases;
    //}

    //public void SetAliases(List<string> aliases) 
    //{ 
    //    Aaliases = aliases;
    //}

    public Action DoExecute;
    public Action<string[]> DoExecuteWithArgs;

    public injectableCommand(string name, Action doExecute, Action<string[]> doExecuteWithArgs)
    {
        Name = name;
        DoExecute = doExecute;
        DoExecuteWithArgs = doExecuteWithArgs;
    }

    public void execute()
    {
        DoExecute?.Invoke();
    }

    public void execute(string[] args)
    {
        DoExecuteWithArgs?.Invoke(args);
    }

    public void Setup(TextWriter writer)
    {
        throw new System.NotImplementedException();
    }
}
