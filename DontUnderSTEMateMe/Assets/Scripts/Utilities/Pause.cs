using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool active;
    private Canvas canvas;
    private Canvas lifesUI;
    private Canvas AbilityUI;
    private Canvas ImageUI;

    // Start is called before the first frame update
    void Start()
    {
        lifesUI = GameObject.Find("LifesUI")?.GetComponent<Canvas>();
        AbilityUI = GameObject.Find("AbilityUI")?.GetComponent<Canvas>();
        ImageUI = GameObject.Find("ImageLoader")?.GetComponent<Canvas>();
        activateUI();
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        DisabledCollectableList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) /*&& !collectables.isActiveAndEnabled && !collectablesList.isActiveAndEnabled*/) 
        {
            Continue();
        }
        
        
    }
    
    public void ShowCollectableList()
    {
        transform.GetChild(1).localPosition = new Vector3(0, 0, 0);
        transform.GetChild(2).localPosition = new Vector3(2000, 0, 0);
    }
     public void DisabledCollectableList()
     {
        transform.GetChild(1).localPosition = new Vector3(2000, 0, 0);
        transform.GetChild(2).localPosition = new Vector3(0, 0, 0);
     }


    public void Continue()
    {
        active = !active;
        canvas.enabled = active;
        Time.timeScale = (active) ? 0 : 1f;
    }

    public void Exit()
    {
        Time.timeScale = 1f;
    }

    public void disableUI()
    {
        if (lifesUI != null) lifesUI.enabled = false;
        if (AbilityUI != null) AbilityUI.enabled = false;
        if (ImageUI != null) ImageUI.enabled = false;
    }

    public void activateUI()
    {
        if (lifesUI != null) lifesUI.enabled = true;
        if (AbilityUI != null) AbilityUI.enabled = true;
        if (ImageUI != null) ImageUI.enabled = true;
    }
}
