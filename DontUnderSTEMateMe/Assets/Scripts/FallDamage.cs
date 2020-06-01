using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    protected float lastPositionY = 0.0f;
    protected float fallDistance = 0.0f;

    protected CharacterController controller;

    [SerializeField]
    protected float maxHeight;

    [SerializeField]
    protected Transform player;

    [SerializeField]
    private GameObject character;

    [SerializeField]
    private GameObject respawn;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Fighter_Controller").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastPositionY > player.transform.position.y)
            fallDistance += lastPositionY - player.transform.position.y;

        lastPositionY = player.transform.position.y;

        if(fallDistance >= 5.0f && controller.isGrounded)
        {
            GameObject charPrinc = Instantiate(character, respawn.transform.position, respawn.transform.rotation);
        }
    }
}
