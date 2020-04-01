using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbOpenDoor : MonoBehaviour
{
    [SerializeField] protected Image iconAbility;
    protected Collider col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //iconAbility.enabled = true;
        iconAbility.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }

}
