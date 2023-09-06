using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] private float speed = 1f;
    [SerializeField] private float gravity = 0.25f;
    private float yVelocity;
    private Player player;
    private CharacterController controller;
    private Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        controller = GetComponent<CharacterController>();
        myTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Direction = Destination - Source
        Vector3 direction = player.transform.position - myTransform.position;
        direction.Normalize();
        Vector3 velocity = direction * speed;

        if (controller.isGrounded == true)
        {

        } else
        {
            yVelocity -= gravity;
        }

        velocity.y = yVelocity;
        direction.y = 0;
        myTransform.rotation = Quaternion.LookRotation(direction);
        controller.Move(velocity * Time.deltaTime);
    }
}
