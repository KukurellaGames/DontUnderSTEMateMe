using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;

public class Platform : MonoBehaviour
{
    [SerializeField] bool isHorizontal;
    [SerializeField] GameObject player;
    protected bool col = false;
    protected bool mov = true;

    //Variables para controlar el movimiento
    protected float horizontal;
    protected float vertical;
    protected bool jump;

    protected Vector2 offset;
    protected vThirdPersonController controller;
    private GameObject actualPlayer;

    // Start is called before the first frame update
    void Start()
    {
        controller = player.GetComponent<vThirdPersonController>();
        actualPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            col = false;
            player.transform.SetParent(null);
        }
        if (actualPlayer.gameObject == null)
        {
            actualPlayer = GameObject.FindGameObjectWithTag("Player");
            col = false;
            actualPlayer.transform.SetParent(null);
        }
        if (!isHorizontal && col)
            movVertical();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
            col = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            col = false;
            actualPlayer.transform.SetParent(null);
        }
    }

    private void movVertical()
    {
        actualPlayer.transform.SetParent(this.transform);
    }
}
