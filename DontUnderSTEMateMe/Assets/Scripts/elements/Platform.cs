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

    // Start is called before the first frame update
    void Start()
    {
        controller = player.GetComponent<vThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        jump = Input.GetButton("Jump");

        
        //Aquí comprobar si el personaje anda, camina o salta
        if (horizontal != 0.0f || vertical != 0.0f || jump == true)
            mov = true;
        else
            mov = false;

        if (isHorizontal && col)
            movementHorizontal();
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
            player.transform.SetParent(null);
        }
    }

    private void movementHorizontal()
    {
        //Tendremos que actualizar la posición cuando salte
        if (col == true && mov == false)
        {
            player.transform.position = new Vector3(this.transform.position.x + offset.x, this.transform.position.y, this.transform.position.z + offset.y);
        }
        else
        {
            offset.x = player.transform.position.x - this.transform.position.x;
            offset.y = player.transform.position.z - this.transform.position.z;
        }

        Debug.Log(offset.x + "  " +offset.y);

    }

    private void movVertical()
    {
        /*
        if (col == true && mov == false)
        {
            player.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
        }*/

        //Aquí hacer el parent
        player.transform.SetParent(this.transform);
    }
}
