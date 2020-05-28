using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectableSystem : MonoBehaviour
{
    [SerializeField] protected string descriptionCollectable;
    [SerializeField] protected string titleCollectable;
    [SerializeField] protected Sprite spriteCollectable;

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
            //añadir a informacion persistente
            Time.timeScale = 0;
            Destroy(this.gameObject);
        }
    }
}
