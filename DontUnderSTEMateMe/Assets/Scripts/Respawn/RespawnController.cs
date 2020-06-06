using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    private static RespawnController _gInstance;
    [SerializeField]
    protected GameObject respawn;

    public GameObject getRespawn()
    {
        return respawn;
    }

    public void setRespawn(GameObject _res)
    {
        respawn = _res;
    }
    //AQUÍ METER FUNCIONES DE RESPAWN DE PERSONAJE

    // Start is called before the first frame update

    private void Awake()
    {
        //GameObject _gInstance = GameObject.FindGameObjectWithTag("GameController");
        if (_gInstance != null && _gInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _gInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
