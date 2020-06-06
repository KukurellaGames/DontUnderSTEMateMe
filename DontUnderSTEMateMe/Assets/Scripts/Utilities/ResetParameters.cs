using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetParameters : MonoBehaviour
{
    private LifeManager _life;

    // Start is called before the first frame update
    void Start()
    {
        _life = GameObject.FindGameObjectWithTag("GameController").GetComponent<LifeManager>();
    }

    public void resetLifes()
    {
        _life.setInitialLifes();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
