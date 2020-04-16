using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerScript : MonoBehaviour
{
    [SerializeField] private Animator handlerAnimator;
    public bool active;
    public bool deactive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            HandlerDown();
            active = false;
        }
        if (deactive)
        {
            HandlerUp();
            deactive = false;
        }
    }

    public void HandlerDown()
    {
        handlerAnimator.SetTrigger("Active");
    }
    public void HandlerUp()
    {
        handlerAnimator.SetTrigger("Deactive");
    }
}
