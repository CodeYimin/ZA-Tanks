using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] Weapon startingWeapon;
    Weapon equippedWeapon;
    
    void Start()
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

    public void OnFire()
    {
        if (equippedWeapon != null)
        {
            equippedWeapon.Fire();
        }
    }
}
