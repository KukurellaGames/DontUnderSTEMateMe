using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    private RespawnController _respawn;
    void Start()
    {
        _respawn = GameObject.FindGameObjectWithTag("GameController").GetComponent<RespawnController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _respawn.setRespawn(this.gameObject);
        }
    }
}
