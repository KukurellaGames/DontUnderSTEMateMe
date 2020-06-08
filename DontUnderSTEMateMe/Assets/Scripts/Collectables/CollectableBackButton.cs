using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBackButton : MonoBehaviour
{
    public void LookForBackCallback()
    {
        GameObject.Find("MainMenuManager").SendMessage("OnMainMenu");
    }
}
