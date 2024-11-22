using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public interface Icommand
{
    public void Setup(TextWriter writer);
    public string Name {get;}
    public void execute();
    public void execute(string[] args);
    public List <string> Aliases {get;}
}

public abstract class Command : ScriptableObject, Icommand
{
    [field: SerializeField] public List<string> Aliases { get; set; }
    public string Name => name;
    public abstract void execute();
    public abstract void execute(string[] args);
  

    public void Setup(TextWriter writer)
    {
        throw new NotImplementedException();
    }
}