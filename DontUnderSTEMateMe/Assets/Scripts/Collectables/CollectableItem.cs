using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] protected Image imageItem;
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
            setCanvasInfo();
            setListInfo();
            //añadir a informacion persistente
            Time.timeScale = 0;
            Destroy(this.gameObject);
        }
    }

    private void setListInfo()
    {
        imageItem.color = new Color(255, 255, 255);
        imageItem.GetComponentInChildren<TextMeshProUGUI>().text = titleCollectable;
        imageItem.GetComponentInChildren<Text>().text = descriptionCollectable;

        GameObject imageDescription = new GameObject("ImageDescription");
        Image image = imageDescription.AddComponent<Image>();
        image.color = new Color(0, 0, 0, 0);
        image.sprite = spriteCollectable;
        image.enabled = false;
        image.transform.parent = imageItem.transform;

        imageItem.GetComponent<Button>().enabled = true;
    }

    private void setCanvasInfo()
    {
        descriptionCanvas.text = descriptionCollectable;
        titleCanvas.text = titleCollectable;
        imageCanvas.sprite = spriteCollectable;
        collectableCanvas.enabled = true;
    }

    private void setPersistentInfo()
    {

    }
}
