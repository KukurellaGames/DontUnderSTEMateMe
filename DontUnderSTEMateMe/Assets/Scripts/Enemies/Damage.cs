using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private RespawnController _respawn;
    [SerializeField]
    private GameObject character;
    // Start is called before the first frame update

    private void Start()
    {
        _respawn = GameObject.FindGameObjectWithTag("GameController").GetComponent<RespawnController>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            GameObject charPrinc= Instantiate(character, _respawn.getRespawn().gameObject.transform.localPosition, _respawn.getRespawn().transform.localRotation);
            Debug.Log(_respawn.getRespawn().transform.localPosition);
        }
    }
}
