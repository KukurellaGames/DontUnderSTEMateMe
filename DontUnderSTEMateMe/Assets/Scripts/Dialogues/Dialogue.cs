using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [SerializeField]
    //Valor mínimo y máximo de oraciones
    [TextArea(3, 10)]
    protected string[] dialogues;

    public string[] getDialogues()
    {
        return dialogues;
    }

    
}
