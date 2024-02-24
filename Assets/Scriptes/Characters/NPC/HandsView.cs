using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class HandsView : MonoBehaviour
{
    protected IAimComponent _aimComponent;

    protected ICanAiming _aimAgent;
    protected Character _owner;

    protected WeaponView _weaponView;
    protected ToolView _toolView;

    public WeaponView WeaponView { get => _weaponView; }
    public ToolView ToolView { get => _toolView; }

    public virtual void Init(ICanAiming aimAgent)
    {
        _aimAgent = aimAgent;
        _owner = _aimAgent.Character;
        _aimComponent = _aimAgent.AimingComponent;
    }
}
