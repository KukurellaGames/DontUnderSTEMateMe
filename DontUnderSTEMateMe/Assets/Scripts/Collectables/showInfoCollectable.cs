using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Experimental.UIElements.StyleEnums;

public class showInfoCollectable : MonoBehaviour
{
    [SerializeField] protected Canvas canvas;

    public void onClick()
    {
        TextMeshProUGUI[] canvasTexts = canvas.GetComponentsInChildren<TextMeshProUGUI>();
        canvasTexts[0].text = GetComponentInChildren<Text>().text;
        canvasTexts[1].text = GetComponentInChildren<TextMeshProUGUI>().text;
        canvas.GetComponentsInChildren<Image>()[2].sprite = GetComponentsInChildren<Image>()[1].sprite;
        canvas.GetComponent<CollectableCanvasScript>().enableCanvas();
    }
}
