using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    public float turnSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent <Animator> ();
        m_Rigidbody = GetComponent <Rigidbody> ();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // makes variables for input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // makes a vector3 and fills in values to values of horizontal and vertical
        m_Movement.Set(horizontal, 0f, vertical);
        // Normalizes each value so it doesn't surpass 1 when going diagonally
        m_Movement.Normalize();

        // if input for horizontal/ vertical is NOT 0, then there is input
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        // isWalking condition is met if either hasHorizontalInput OR hasVerticalInput is true
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        // sets the IsWalking Animator Condition to whatever the isWalking variable is set to
        m_Animator.SetBool("IsWalking", isWalking);

        //sets a vector for which way you want the character to look
        //RotateTowards take 4 paramaters, 1 where the character is looking, 2 where it is trying to look, 3 radians, and 4 magnitude
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);

        // creates a rotatoin looking in the direction of the given paramater
        m_Rotation = Quaternion.LookRotation(desiredForward);

    }

    void OnAnimatorMove()
    {
        // moves rigid body from its original position to whatever direction movement is in * the magnitude of the root motion
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);

        //sets rotation of rigid body
        m_Rigidbody.MoveRotation (m_Rotation);
    }


}
