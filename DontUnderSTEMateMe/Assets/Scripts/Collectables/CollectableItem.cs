using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] protected int id;
    [SerializeField] protected string descriptionCollectable;
    [SerializeField] protected string titleCollectable;
    [SerializeField] protected Sprite spriteCollectable;

    [SerializeField] protected Canvas collectableList;
    [SerializeField] protected Canvas collectableCanvas;
    [SerializeField] protected TextMeshProUGUI descriptionCanvas;
    [SerializeField] protected TextMeshProUGUI titleCanvas;
    [SerializeField] protected Image imageCanvas;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            descriptionCanvas.text = descriptionCollectable;
            titleCanvas.text = titleCollectable;
            collectableCanvas.enabled = true;
            imageCanvas.sprite = spriteCollectable;
            setListInfo(collectableList);
            //añadir a informacion persistente
            Time.timeScale = 0;
            Destroy(this.gameObject);
        }
    }

    private void setListInfo(Canvas collectableList)
    {
        Image imageItem = collectableList.GetComponentsInChildren<Image>()[id+2];
        imageItem.color = new Color(255, 255, 255);
        imageItem.GetComponentInChildren<TextMeshProUGUI>().text = titleCollectable;
    }
}
