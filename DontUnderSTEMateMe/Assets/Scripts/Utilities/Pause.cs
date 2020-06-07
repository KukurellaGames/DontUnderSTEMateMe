using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool active;
    private Canvas canvas;
    [SerializeField] Canvas collectables;
    [SerializeField] Canvas collectablesList;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
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
            disabledCollectableList();
        }
    }

    public void showCollectableList()
    {
        GetComponentInParent<Canvas>().enabled = false;
        collectablesList.enabled = true;
    }
     public void disabledCollectableList()
     {
        GetComponentInParent<Canvas>().enabled = true;
        collectablesList.enabled = false;
     }

    public void Continue()
    {
        active = !active;
        canvas.enabled = active;
        Time.timeScale = (active) ? 0 : 1f;
    }
}
