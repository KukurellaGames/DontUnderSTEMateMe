using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;

public class FallDamage : MonoBehaviour
{
    protected float lastPositionY = 0.0f;
    protected float fallDistance = 0.0f;

    protected vThirdPersonController controller;

    protected Transform player;

    protected GameObject character;

    [SerializeField]
    protected float maxHeight;

    [SerializeField]
    protected GameObject respawn;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<vThirdPersonController>();
        player = this.transform;
        character = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastPositionY > player.transform.position.y && !controller.isGrounded)
            fallDistance += lastPositionY - player.transform.position.y;

        lastPositionY = player.transform.position.y;

        if(fallDistance >= maxHeight && controller.isGrounded)
        {
            lastPositionY = 0.0f;
            fallDistance = 0.0f;
            Destroy(this.gameObject);
            GameObject charPrinc = Instantiate(character, respawn.gameObject.transform.localPosition, respawn.transform.localRotation);
        }
    }
}
