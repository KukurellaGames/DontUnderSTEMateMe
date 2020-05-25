using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    [SerializeField]
    private GameObject respawn;
    [SerializeField]
    private GameObject character;
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //collision.gameObject.transform.position = respawn.transform.position;
            Destroy(collision.gameObject);
            GameObject charPrinc= Instantiate(character, respawn.transform.position, respawn.transform.rotation);
        }
    }
}
