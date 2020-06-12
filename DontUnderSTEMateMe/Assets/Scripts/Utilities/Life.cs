using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    private LifeManager _life;
    private AudioSource _lifeSound;

    void Start()
    {
        _life = GameObject.FindGameObjectWithTag("GameController").GetComponent<LifeManager>();
        _lifeSound = transform.parent.GetComponentInParent<AudioSource>();
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        _life.IncrementLife();
        _lifeSound.Play();
        Destroy(transform.parent.gameObject);
    }
   
}
