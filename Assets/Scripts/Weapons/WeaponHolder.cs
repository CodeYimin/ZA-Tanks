using UnityEngine;

namespace Weapons
{
    public class WeaponHolder : MonoBehaviour
    {
        [SerializeField] private Weapon startingWeapon;
        private Weapon _equippedWeapon;
    
        private void Start()
        {
            if (startingWeapon != null)
            {
                EquipWeapon(startingWeapon);
            }
        }

        public void EquipWeapon(Weapon weaponToEquip)
        {
            if (_equippedWeapon != null)
            {
                Destroy(_equippedWeapon.gameObject);
            }

            _equippedWeapon = Instantiate(weaponToEquip, transform.position, transform.rotation);
            _equippedWeapon.transform.parent = transform;
        }

    }
}
