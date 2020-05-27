using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableSystem : MonoBehaviour
{
    [SerializeField] protected string text;
    [SerializeField] protected Canvas collectableCanvas;
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Text collectableText = collectableCanvas.GetComponentInChildren<Text>();
            collectableText.text = text;
            collectableCanvas.enabled = true;
            //añadir a informacion persistente
            Time.timeScale = 0;
            Destroy(this.gameObject);
        }
    }
}
