using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private FallDamage fallDamage;
    protected AudioSource _audioSourc;
    private LifeManager _lifeManager;
    private RespawnController _respawn;
    [SerializeField]
    private GameObject character;
    // Start is called before the first frame update

    private void Start()
    {
        _audioSourc = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
        _lifeManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<LifeManager>();
        _respawn = GameObject.FindGameObjectWithTag("GameController").GetComponent<RespawnController>();
        fallDamage = GameObject.FindGameObjectWithTag("GameController").GetComponent<FallDamage>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            fallDamage.enabled = false;
            Destroy(collision.gameObject);
            GameObject charPrinc = Instantiate(character, _respawn.getRespawn().gameObject.transform.localPosition, _respawn.getRespawn().transform.localRotation);
            charPrinc.transform.SetParent(null);
            _lifeManager.isDead();
            fallDamage.lastPositionY = 0.0f;
            fallDamage.fallDistance = 0.0f;
        }
    }
}
