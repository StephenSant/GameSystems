using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPersonController
{
public class PlayerController : MonoBehaviour
{
    #region Variables
    [Header("Movement Variables")]
    public float moveSpeed = 5;
    public float jumpHeight = 5;
    private bool isJumping;
    private Vector3 moveDir;
    private Rigidbody rigidbody;
    private Vector3 spawnPoint;
    [Header("Camera Variables")]
    public bool rotateToMainCamera = false;
    public float sensitvity = 5;
    private GameObject myCamera;
    [Header("Weapon Variables")]
    public Weapon[] weapons;
    private Weapon currentWeapon;

    private Interactable interactObject;
    #endregion
    #region Raycast
    [Header("Physics")]
    public float rayDistance = 1.1f;
    private void OnDrawGizmosSelected()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * rayDistance);
    }
    #endregion
    #region TriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        interactObject = other.GetComponent<Interactable>();
    }
    private void OnTriggerExit(Collider other)
    {
        interactObject = null;
    }
    #endregion
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        myCamera = GameObject.Find("Main Camera");
        spawnPoint = this.transform.position;
    }

    bool IsGrounded()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(groundRay, out hit, rayDistance))
        {
            return true;
        }
        return false;
    }

    void Update()
    {
        #region Camera Rotation
        Vector3 camEuler = Camera.main.transform.eulerAngles;
        if (rotateToMainCamera)
        {
            moveDir = Quaternion.AngleAxis(camEuler.y, Vector3.up) * moveDir;
        }
        #endregion
        #region Forward, backward, left and right movement
        Vector3 force = new Vector3(moveDir.x, rigidbody.velocity.y, moveDir.z);
        #endregion
        #region Jump
        //Check if space is pressed
        if (isJumping && IsGrounded())
        {
            //Jump!
            force.y = jumpHeight;
            isJumping = false;
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
        Quaternion playerRotation = Quaternion.AngleAxis(camEuler.y, Vector3.up);
        transform.rotation = playerRotation;
    }
    #region Weapon
    private void DisableAllWeapons()
    {
        foreach (Weapon weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }
    }

    public void SelectWeapon(int index)
    {
        if (index < 0 || index >= weapons.Length) { return; }
        DisableAllWeapons();
        weapons[index].gameObject.SetActive(true);
        currentWeapon = weapons[index];
    }
    #endregion

    public void Move(float inputH, float inputV)
    {
        moveDir = new Vector3(inputH, 0, inputV);
        moveDir *= moveSpeed;
    }

    public void Jump()
    {
        isJumping = true;
    }

    public void Attack()
    {
        currentWeapon.Attack();
    }
    public void Interact()
    {
        if (interactObject)
        {
            interactObject.Interact();
        }
    }
}}