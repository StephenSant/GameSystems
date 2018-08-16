using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [Header("Movement")]
    public float moveSpeed = 5;
    public float jumpHeight = 5;
    private Rigidbody rigidbody;
    private Vector3 spawnPoint;
    [Header("Physics")]
    public float rayDistance = 1f;
    [Header("Camera Variables")]
    public float sensitvity = 5;
    private GameObject myCamera;
    #endregion
    #region Raycast
    // Implement this OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn
    private void OnDrawGizmosSelected()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * rayDistance);
    }
    #endregion
    // Use this for initialization
    void Start()
    {
        //Set up Components
        rigidbody = this.GetComponent<Rigidbody>();
        myCamera = GameObject.Find("Main Camera");
        spawnPoint = this.transform.position;
    }

    bool IsGrounded()
    {
        //Makes a ray
        Ray groundRay = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(groundRay, out hit, rayDistance))
        {
            //Return true if is grounded
            return true;
        }
        //Return true if is NOT grounded
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        #region Forward, backward, left and right movement
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");
        Vector3 moveDir = new Vector3(-inputV, 0, inputH);
        moveDir = moveDir * moveSpeed;
        Vector3 force = new Vector3(moveDir.x, rigidbody.velocity.y, moveDir.z);

        #endregion
        #region Jump
        //Check if space is pressed
        if (Input.GetButton("Jump")&& IsGrounded())
        {
            //Jump!
            force.y = jumpHeight;
        }

        #endregion
        #region Direction moving
        rigidbody.velocity = force;

        if (moveDir.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(moveDir);
        }
        #endregion
        #region Respawn
        if (this.transform.position.y < -10)
        {
            transform.position = spawnPoint;
            Debug.Log("DEAD");
        }
        #endregion
    }
}