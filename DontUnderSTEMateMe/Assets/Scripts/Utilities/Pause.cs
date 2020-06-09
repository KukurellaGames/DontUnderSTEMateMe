using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool active;
    private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        DisabledCollectableList();
        /*
        collectables = GameObject.FindGameObjectWithTag("CollectableContainer").transform.GetChild(1).GetComponent<Canvas>();
        collectablesList = GameObject.FindGameObjectWithTag("CollectableContainer").transform.GetChild(0).GetComponent<Canvas>();

        if (Input.GetKeyDown(KeyCode.Escape) && !collectables.isActiveAndEnabled && collectablesList.isActiveAndEnabled)
        {
            DisabledCollectableList();
        }
        */
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
}
