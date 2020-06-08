using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDialogCallback : MonoBehaviour
{
    public void FirstDialogCallbackExec()
    {
        GetComponent<Animator>().SetTrigger("Open");
    }
}
