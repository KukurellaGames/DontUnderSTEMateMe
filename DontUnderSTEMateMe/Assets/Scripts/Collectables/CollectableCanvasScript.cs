using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableCanvasScript : MonoBehaviour
{
    [SerializeField] Canvas collectableCanvas;
    [SerializeField] Button exitButton;
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

    private void disableCanvas()
    {
        collectableCanvas.enabled = false;
        Time.timeScale = 1f;
    }
}
