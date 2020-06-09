using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectableExpanded : MonoBehaviour
{
    private Canvas Expanded;
    void Start()
    {
        Expanded = GameObject.FindGameObjectWithTag("CollectableExpanded").transform.GetComponent<Canvas>();
    }

    public void SetInfo()
    {
        TextMeshProUGUI[] canvasTexts = Expanded.GetComponentsInChildren<TextMeshProUGUI>();
        canvasTexts[0].text = GetComponentInChildren<Text>().text;
        canvasTexts[1].text = GetComponentInChildren<TextMeshProUGUI>().text;
        Expanded.GetComponentsInChildren<Image>()[2].sprite = GetComponentsInChildren<Image>()[1].sprite;

    }

    public void HideExpanded()
    {
        Expanded.enabled = false;
    }

    public void ShowExpanded()
    {
        SetInfo();
        Expanded.enabled = true;
    }
}
