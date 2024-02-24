using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstrHandsView : HandsView
{
    private WeaponView[] _naturalWeapons;

    public void Init(ICanShoot shooter, WeaponView[] naturalWeponsPrefabs)
    {
        base.Init(shooter);

        var weponPrefabsLenght = naturalWeponsPrefabs.Length;

        _naturalWeapons = new WeaponView[weponPrefabsLenght];

        for (int i = 0; i < weponPrefabsLenght; i++)
        {            
            var instance = Instantiate(naturalWeponsPrefabs[i], transform);
            _naturalWeapons[i] = instance;
        }

        _weaponView = _naturalWeapons[0];
        _weaponView.Init(_aimAgent, this);
      
    }

    public void SetActiveWeapon(int weaponIndex)
    {
        _weaponView = _naturalWeapons[weaponIndex];
    }
}
