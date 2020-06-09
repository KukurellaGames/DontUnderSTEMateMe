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

    protected GameObject uiCollectables;
    

    private CollectableContainer container;

    private void Start()
    {
        container = GameObject.FindGameObjectWithTag("CollectableContainer").GetComponent<CollectableContainer>();
        if (container.getList().collectables[_id].pickup)
            Destroy(this.gameObject);

        uiCollectables = GameObject.FindGameObjectWithTag("CollectableContainer").GetComponent<CollectableContainer>().GetUiCollectables()[_id];
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
        descriptionCanvas.text = uiCollectables.transform.GetChild(1).GetComponent<Text>().text;
        titleCanvas.text = uiCollectables.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        imageCanvas.sprite = uiCollectables.GetComponent<Image>().sprite;
    }
}
