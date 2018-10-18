using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ThirdPersonController { 
public class PlayerInput : MonoBehaviour
{
    public PlayerController player;
    public int weaponIndex = 0;

    private void Start()
    {
        player = GetComponent<PlayerController>();
        player.SelectWeapon(weaponIndex);
    }

    void Update ()
    {
        WeaponSwitch();
        float inputH = Input.GetAxisRaw("Horizontal");
        float inputV = Input.GetAxisRaw("Vertical");
        player.Move(inputH, inputV);

        if (Input.GetButtonDown("Jump"))
        {
            player.Jump();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            player.Attack();
        }

        if (Input.GetKeyDown(KeyCode.F)) { player.Interact(); }
    }
    private void WeaponSwitch()
    {
        int currentIndex = weaponIndex;
        if (Input.GetKeyDown(KeyCode.Q) && weaponIndex > 0)
        {
            currentIndex--;
        }
        if (Input.GetKeyDown(KeyCode.E) && weaponIndex < player.weapons.Length-1)
        {
            currentIndex++;

        }
        if (currentIndex != weaponIndex)
        {
            // Update weapon index
            weaponIndex = currentIndex;
            // Select weaponIndex
            player.SelectWeapon(weaponIndex);
        }
    }
}
}