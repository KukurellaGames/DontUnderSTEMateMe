using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        jump = Input.GetButton("Jump");

        //Aquí comprobar si el personaje anda, camina o salta
        if (horizontal != 0.0f || vertical != 0.0f || jump == true)
            mov = true;
        else
            mov = false;

        if (isHorizontal)
            movementHorizontal();
        else
            movVertical();

    }

    private void OnCollisionEnter(Collision collision)
    {
        col = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        col = false;
    }

    private void movementHorizontal()
    {
        if (col == true && mov == false)
        {
            player.transform.position = new Vector3(this.transform.position.x + offset.x, this.transform.position.y, this.transform.position.z + offset.y);
        }
        else
        {
            offset.x = player.transform.position.x - this.transform.position.x;
            offset.y = player.transform.position.z - this.transform.position.z;
        }
    }

    private void movVertical()
    {
        if (col == true && mov == false)
        {
            player.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
        }
    }
}
