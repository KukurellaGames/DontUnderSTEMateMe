using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScenes : MonoBehaviour
{
    private ChangeScene _chScene;
    void Start()
    {
        _chScene = GetComponent<ChangeScene>(); 
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _chScene.onPointerClick();
        }
    }
}
