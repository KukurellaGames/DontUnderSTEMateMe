using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableCanvasScript : MonoBehaviour
{
    [SerializeField] Canvas collectableCanvas;
    [SerializeField] Button exitButton;
    [SerializeField] Canvas collectableList;
    [HideInInspector] public bool mustPauseGame = false;
    private void Start()
    {
        exitButton.onClick.AddListener(disableCanvas);
    }
    private void Update()
    {
        if(collectableCanvas.isActiveAndEnabled)
        {
            //Pause;
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                disableCanvas();
            }
        }
    }

    public void disableCanvas()
    {
        collectableCanvas.enabled = false;
        //if(mustPauseGame)
        //if(!collectableList.isActiveAndEnabled && mustPauseGame)
            Time.timeScale = 1f;
    }

    public void enableCanvas()
    {
        collectableCanvas.enabled = true;
        if(mustPauseGame)
            Time.timeScale = 0f;
    }
}
