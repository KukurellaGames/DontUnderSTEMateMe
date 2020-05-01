using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    private GameObject bullet;
    private float counterTime = 0;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float distMax;
    [SerializeField]
    private GameObject _principalCharacter;
    [SerializeField]
    private float _offset;
    private Animator anim;

    private bool _down = false;
    private float posUp;
    private float posDown;


    private void Awake()
    {
        posUp = this.transform.localPosition.y + _offset;
        posDown = this.transform.localPosition.y - _offset;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float _dist = Vector3.Distance(_principalCharacter.transform.position, transform.position);
        if(_dist <= distMax)
        {
            transform.LookAt(_principalCharacter.transform);
            counterTime += Time.deltaTime;
            if (counterTime > spawnTime)
            {
                Shoot();
                counterTime = 0;
            }
        }
        
        if (!_down)
        {
            this.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        }
        else
        {
            this.transform.Translate(Vector3.down * Time.deltaTime, Space.World);
        }

        if (this.transform.localPosition.y >= posUp)
        {
            _down = true;
        }

        if (this.transform.localPosition.y <= posDown)
        {
            _down = false;
        }
    }

    private void Shoot()
    {
        anim.SetBool("Walk Forward", false);
        bullet = (GameObject)Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
        //Debug.Log(_principalCharacter.transform.localPosition - this.transform.localPosition);
        bullet.GetComponent<Rigidbody>().AddForce(this.transform.forward * 100 * bulletSpeed);
        anim.SetTrigger("Attack 01");
        Invoke("Destroy", 1);
    }

    private void Destroy()
    {
        Destroy(bullet);
        Debug.Log("hola");
    }
}
