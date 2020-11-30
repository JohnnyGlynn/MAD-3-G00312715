using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody myRigidBody;
    private Vector3 move;
    private Quaternion corner;
    public Transform[] target;

    private int current;

    [SerializeField] float runSpeed = 0.075f;
    //[SerializeField] float jumpSpeed = 100.0f;

    //public float gravity = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
    }

    void Jump()
    {

        if (Input.GetButtonDown("Jump"))
        {
            myRigidBody.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
        }
           
    }

    void Run()
    {
        Vector3 end = target[target.Length -1].position;

        if (transform.position != target[current].position && transform.position != end)
        {
            Vector3 targetDirection = target[current].position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 3.0f * Time.deltaTime, 0.0f);

            if (targetDirection != newDirection) {
                transform.rotation = Quaternion.LookRotation(newDirection);
            }

            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, runSpeed * Time.deltaTime);
            myRigidBody.MovePosition(pos);
        }
        else current = (current + 1) % target.Length;
    }


}
