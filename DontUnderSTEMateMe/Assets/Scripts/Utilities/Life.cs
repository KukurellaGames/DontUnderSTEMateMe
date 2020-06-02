using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    private LifeManager _life;

    void Start()
    {
        _life = GameObject.FindGameObjectWithTag("GameController").GetComponent<LifeManager>();
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        _life.IncrementLife();
        Destroy(transform.parent.gameObject);
        //Destroy(this.gameObject);
    }
   
}
