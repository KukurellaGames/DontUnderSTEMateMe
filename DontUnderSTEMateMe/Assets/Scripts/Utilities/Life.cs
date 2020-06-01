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

    private void OnTriggerEnter(Collider other)
    {
        _life.IncrementLife();
        Destroy(this.gameObject);
    }
}
