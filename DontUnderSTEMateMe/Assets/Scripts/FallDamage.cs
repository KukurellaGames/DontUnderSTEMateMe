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

    [SerializeField]
    private GameObject character;
    //protected GameObject character;

    [SerializeField]
    protected float maxHeight;

    private LifeManager _lifeManager;
    private RespawnController _respawn;

    // Start is called before the first frame update
    void Start()
    {
        getInformation();
        _lifeManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<LifeManager>();
        _respawn = GameObject.FindGameObjectWithTag("GameController").GetComponent<RespawnController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null || controller == null)
        {
            getInformation();
        }
        else
        {
            if (lastPositionY > player.position.y && !controller.isGrounded)
                fallDistance += lastPositionY - player.position.y;

            lastPositionY = player.position.y;

            if (fallDistance >= maxHeight && controller.isGrounded)
            {
                lastPositionY = 0.0f;
                fallDistance = 0.0f;
                Destroy(controller.gameObject);
                GameObject charPrinc = Instantiate(character, _respawn.getRespawn().gameObject.transform.localPosition, _respawn.getRespawn().transform.localRotation);
                _lifeManager.isDead();
            }

            if (controller.isGrounded)
                fallDistance = 0.0f;
        }
    }

    void getInformation()
    {
        controller = GameObject.FindGameObjectWithTag("Player")?.GetComponent<vThirdPersonController>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }
}
