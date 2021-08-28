using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private Weapon startingWeapon;
    private Weapon equippedWeapon;
    
    private void Start()
    {
        if (startingWeapon != null)
        {
            EquipWeapon(startingWeapon);
        }
    }

    public void EquipWeapon(Weapon weaponToEquip)
    {
        if (equippedWeapon != null)
        {
            Destroy(equippedWeapon.gameObject);
        }

        equippedWeapon = Instantiate(weaponToEquip, transform.position, transform.rotation);
        equippedWeapon.transform.parent = transform;
    }

}
