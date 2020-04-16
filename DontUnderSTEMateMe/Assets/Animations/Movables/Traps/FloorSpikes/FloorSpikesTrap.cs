using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpikesTrap : MonoBehaviour
{
    [SerializeField] private Animator spikeAnimator;
    public bool activUp;
    public bool activDown;
    // Start is called before the first frame update
    void Start()
    {
        //primera opcion
        
        //segunda opcion
    }

    // Update is called once per frame
    //si no se hace nada, por rendimiento se deberia eliminar
    void Update()
    {
        if(activUp)
        {
            SpikesUp();
            activUp = false;
        }
        if (activDown)
        {
            SpikesDown();
            activDown = false;
        }
    }

    public void SpikesUp()
    {
        spikeAnimator.SetTrigger("Up");
    }
    public void SpikesDown()
    {
        spikeAnimator.SetTrigger("Down");
    }
}
