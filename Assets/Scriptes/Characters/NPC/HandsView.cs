using UnityEngine;


public class HandsView : MonoBehaviour
{
    [SerializeField] protected Transform _leftWrist;
    [SerializeField] protected Transform _rightWrist;
    [SerializeField] protected Transform _chest;

    protected IAimComponent _aimComponent;

    protected ICanAiming _aimAgent;
    protected Character _owner;

    protected WeaponView _weaponView;
    protected ToolView _toolView;
    protected InventoryBase _inventory;

    public WeaponView WeaponView { get => _weaponView; }
    public ToolView ToolView { get => _toolView; }

    public virtual void Init(Character pawn)
    {
        _aimAgent = pawn as ICanShoot;
        _owner = pawn;
        _inventory = _owner.Inventory;

        if (_aimAgent != null)
        {
            _aimComponent = _aimAgent.AimingComponent;
        }
        
        _inventory.onNewItemEqiuped += ShowEquipedTool;
        ShowEquipedTool();
    }


    public virtual void ShowEquipedTool()
    {
        if (_inventory == null)
        {
            Debug.LogError("Have not Inventory");
            return;
        }
        var equipedItem = _inventory.EquipedItem;

        if (equipedItem == null)
        {
            DestroyPreviousView();
            return;
        }
        var viewPrefab = equipedItem.ItemView;

        if (viewPrefab != _weaponView)
        {
            DestroyPreviousView();

            if (viewPrefab == null)
            {
                return;
            }

            var view = Instantiate(viewPrefab, transform);

            if (view is WeaponView weaponView)
            {
                _weaponView = view;
                _weaponView.Init(_owner, this);
            }
        }
    }

    protected void DestroyPreviousView()
    {
        if (_weaponView != null)
        {
            Destroy(_weaponView);
            _weaponView = null;
        }
    }

    protected void OnDestroy()
    {
        if (_inventory != null)
        {
            _inventory.onNewItemEqiuped -= ShowEquipedTool;
        }
    }
}
