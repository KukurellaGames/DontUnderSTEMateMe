using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] protected int _id;

    [SerializeField] protected Image imageItem;
    [SerializeField] protected string descriptionCollectable;
    [SerializeField] protected string titleCollectable;
    [SerializeField] protected Sprite spriteCollectable;

    [SerializeField] protected Canvas collectableList;
    [SerializeField] protected Canvas collectableCanvas;
    [SerializeField] protected TextMeshProUGUI descriptionCanvas;
    [SerializeField] protected TextMeshProUGUI titleCanvas;
    [SerializeField] protected Image imageCanvas;

    private CollectableContainer container;

    private void Start()
    {
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
            setCanvasInfo();
            container.UnlockCollectable(_id);
            //añadir a informacion persistente
            Time.timeScale = 0;
            Destroy(this.gameObject);
        }
    }

    private void setCanvasInfo()
    {
        descriptionCanvas.text = container.getList().collectables[_id].description;
        titleCanvas.text = container.getList().collectables[_id].title;
        imageCanvas.sprite = spriteCollectable;
        collectableCanvas.enabled = true;
    }

    private void setPersistentInfo()
    {

    }
}
