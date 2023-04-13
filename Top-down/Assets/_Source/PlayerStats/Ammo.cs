using UnityEngine;

namespace PlayerStats
{
    public class Ammo
    {
        public int AmmoAmount
        {
            get;
            private set;
        }

        private readonly int _maxAmmo;

        public Ammo(int maxAmmo)
        {
            AmmoAmount = maxAmmo;
            _maxAmmo = maxAmmo;
        }

        public void RemoveAmmo(int ammoToRemove)
        {
            ChangeAmmo(-ammoToRemove);
        }

        public void AddAmmo(int ammoToAdd)
        {
            ChangeAmmo(ammoToAdd);
        }

        private void ChangeAmmo(int ammoChange)
        {
            AmmoAmount += ammoChange;
            Mathf.Clamp(AmmoAmount, 0, _maxAmmo);
        }

    }
}

