using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMenu : MonoBehaviour
{
    private Canvas lifesUI;
    private Canvas AbilityUI;
    private Canvas ImageUI;

    // Start is called before the first frame update
    void Start()
    {
        lifesUI = GameObject.Find("LifesUI")?.GetComponent<Canvas>();
        AbilityUI = GameObject.Find("AbilityUI")?.GetComponent<Canvas>();
        ImageUI = GameObject.Find("ImageLoader")?.GetComponent<Canvas>();

        if (lifesUI != null) lifesUI.enabled = false;
        if (AbilityUI != null) AbilityUI.enabled = false;
        if (ImageUI != null) ImageUI.enabled = false;
    }

    public void ActivateUI()
    {
        if (lifesUI != null) lifesUI.enabled = true;
        if (AbilityUI != null) AbilityUI.enabled = true;
        if (ImageUI != null) ImageUI.enabled = true;
    }
}
