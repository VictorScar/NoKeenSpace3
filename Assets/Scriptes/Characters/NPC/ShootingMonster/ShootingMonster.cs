using UnityEngine;

public class ShootingMonster : Monster, ICanShoot
{
    [SerializeField] protected float _shootDistance = 10f;
    
    [SerializeField] private WeaponView[] _naturalWeapons; 
    
    public WeaponView EquipedWeapon => _handsView.WeaponView;

    public Character Character => this;

    public override void Init()
    {
        base.Init();
       
        _inventory?.Init(this);
        _animController?.Init(this);
        _handsView.Init(this);

    }

    public bool Shoot()
    {
        if (AimingComponent == null)
        {
            return false;
        }
              

        if (EquipedWeapon == null)
        {
            return false;
        }

        EquipedWeapon.Fire();
        OnAttacking();
        return true;
    }
}
