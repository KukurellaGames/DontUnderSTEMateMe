using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] protected int _id;
    [SerializeField] protected Sprite spriteCollectable;
    [SerializeField] protected TextMeshProUGUI descriptionCanvas;
    [SerializeField] protected TextMeshProUGUI titleCanvas;
    [SerializeField] protected Image imageCanvas;
    [SerializeField] protected GameObject pause;

    protected Collectable uiCollectables;
    

    private CollectableContainer container;

    private void Start()
    {
        container = GameObject.FindGameObjectWithTag("CollectableContainer").GetComponent<CollectableContainer>();
        if (container.getList().collectables[_id].pickup)
        {
            Destroy(this.gameObject);
            return;
        }
        uiCollectables = container.GetComponent<CollectableContainer>().getList().collectables[_id];
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
            Destroy(this.gameObject);
        }
    }

    private void SetCanvasInfo()
    {
        descriptionCanvas.text = uiCollectables.description;
        titleCanvas.text = uiCollectables.title;
        imageCanvas.sprite = spriteCollectable;
        pause.GetComponent<Pause>().Continue();
        pause.GetComponent<Pause>().ShowCollectableList();
        GameObject.FindGameObjectWithTag("CollectableExpanded").GetComponent<Canvas>().enabled = true;
    }
}
