using UnityEngine;

namespace Assets.Scripts.Game
{
    public class WeaponHandler : MonoBehaviour
    {
        [SerializeField] private Weapon weapon;
        public Weapon GetWeapon()
        {
            return weapon;
        }
    }

}
