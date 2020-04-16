using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilSpikesTrap : MonoBehaviour
{
    [SerializeField] private Animator spikeAnimator;
    public bool activUp;
    public bool activDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activUp)
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
