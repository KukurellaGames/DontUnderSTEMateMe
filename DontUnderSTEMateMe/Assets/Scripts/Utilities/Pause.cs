using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool active;
    private Canvas canvas;
    [SerializeField] Canvas collectables;
    private Canvas collectablesList;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        collectablesList = GameObject.FindGameObjectWithTag("CollectableContainer").transform.GetChild(0).GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !collectables.isActiveAndEnabled && !collectablesList.isActiveAndEnabled) 
        {
            Continue();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !collectables.isActiveAndEnabled && collectablesList.isActiveAndEnabled)
        {
            DisabledCollectableList();
        }
    }

    public void ShowCollectableList()
    {
        collectablesList.enabled = true;
        //this.gameObject.GetComponent<Canvas>().enabled = false;
    }
     public void DisabledCollectableList()
     {
        collectablesList.enabled = false;
        //this.gameObject.GetComponent<Canvas>().enabled = true;
     }

    public void Continue()
    {
        active = !active;
        canvas.enabled = active;
        Time.timeScale = (active) ? 0 : 1f;
    }
}
