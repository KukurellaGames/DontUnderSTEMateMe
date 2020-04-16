using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilSpikesTrap : TrapTemplate
{
    [SerializeField] private Animator spikeAnimator;
    private bool Up = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public override void SpikesMovement()
    {
        if(Up)
        {
            SpikesDown();
        }
        else 
        {
            SpikesUp();
        }
            
    }

    public void SpikesUp()
    {
        spikeAnimator.SetTrigger("Up");
        Up = true;
    }
    public void SpikesDown()
    {
        spikeAnimator.SetTrigger("Down");
        Up = false;
    }
}
