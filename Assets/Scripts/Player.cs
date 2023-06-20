using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forceMultiplier = 3f;
    public float maximumVelocity = 3f;

    private Rigidbody playerRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");

        if (playerRigidBody.velocity.magnitude <= 3f)
        {
            playerRigidBody.AddForce(new Vector3(horizontalInput * forceMultiplier, 0, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crate"))
        {
            Destroy(gameObject);
        }
    }
}
