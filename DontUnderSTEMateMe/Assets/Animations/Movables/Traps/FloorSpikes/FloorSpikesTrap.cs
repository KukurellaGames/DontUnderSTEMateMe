using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpikesTrap : TrapTemplate
{
    [SerializeField] private Animator spikeAnimator;
    private AudioSource audio;
    private bool Up;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public override void SpikesMovement()
    {
        if (Up)
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
        audio.Play();
        Up = true;
    }
    public void SpikesDown()
    {
        spikeAnimator.SetTrigger("Down");
        audio.Play();
        Up = false;
    }
}
