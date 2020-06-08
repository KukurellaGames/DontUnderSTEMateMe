using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] protected int _id;
    [SerializeField] protected Sprite spriteCollectable;

    protected Canvas collectableCanvas;
    protected TextMeshProUGUI descriptionCanvas;
    protected TextMeshProUGUI titleCanvas;
    protected Image imageCanvas;

    private CollectableContainer container;

    private void Start()
    {
        collectableCanvas = GameObject.FindGameObjectWithTag("CollectableContainer").transform.GetChild(1).GetComponent<Canvas>();
        descriptionCanvas = collectableCanvas.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        titleCanvas = collectableCanvas.transform.GetChild(5).GetComponent<TextMeshProUGUI>();
        imageCanvas = collectableCanvas.transform.GetChild(3).GetComponent<Image>();

        container = GameObject.FindGameObjectWithTag("CollectableContainer").GetComponent<CollectableContainer>();
        if (container.getList().collectables[_id].pickup)
            Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SetCanvasInfo();
            container.UnlockCollectable(_id);
            Time.timeScale = 0;
            Destroy(this.gameObject);
        }
    }

    private void SetCanvasInfo()
    {
        descriptionCanvas.text = container.getList().collectables[_id].description;
        titleCanvas.text = container.getList().collectables[_id].title;
        imageCanvas.sprite = spriteCollectable;
        collectableCanvas.enabled = true;
    }
}
