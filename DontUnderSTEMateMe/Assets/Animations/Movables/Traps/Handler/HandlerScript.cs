using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerScript : MonoBehaviour
{
    [SerializeField] private Animator handlerAnimator;
    [SerializeField] private List<TrapTemplate> spikesList;

    private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            OnHandler();
    }
    public void HandlerDown()
    {
        handlerAnimator.SetTrigger("Active");
        active = true;
    }
    public void HandlerUp()
    {
        handlerAnimator.SetTrigger("Deactive");
        active = false;
    }

    public void OnHandler()
    {
        if(active)
        {
            HandlerUp();
        }
        else 
        {
            HandlerDown();
        }
        Invoke("NotifySpikes", 1);
    }

    private void NotifySpikes()
    {
        foreach (TrapTemplate spike in spikesList)
        {
            spike.SpikesMovement();
        }
    }
}
