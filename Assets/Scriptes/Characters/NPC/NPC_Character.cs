using System;
using UnityEngine;

public class NPC_Character : Character
{
    [SerializeField] protected Player _target;

    [SerializeField] protected NPC_LookPoint _lookPoint;

    //[SerializeField] protected HandsView _handsView;

    [SerializeField] protected NPCAnimationController _animController;
    [SerializeField] protected NPC_Scanner _npcScanner;

    protected NPC_Mover _npcMover;
    protected bool _isSprinting = false;

    public Action onAttacking;

    public override void Init()
    {
        base.Init();
        
        _npcMover = _mover as NPC_Mover;
        _handsView.Init(this);
        _animController?.Init(this);
    }

    public Player Target { get => _target; set => _target = value; }

    public override bool IsSprinting
    {
        get
        {
            return _isSprinting;
        }
        set
        {
            _isSprinting = value;

            if (_isSprinting)
            {
                _moveSpeed = _sprintSpeed;
            }
            else
            {
                _moveSpeed = _baseSpeed;
            }
        }
    }

    public NPC_LookPoint LookPoint { get => _lookPoint; }

    public void FindTarget()
    {
        var player = _npcScanner.FindPlayer();

        if (player != null)
        {
            _target = player;
        }
    }

    public void GoToTarget()
    {
        _npcMover.MoveTo(_target.transform.position, _moveSpeed);
    }

    public override void StopMove()
    {
        _mover.StopMoving();
    }

    public bool LookAt(Vector3 targetPos)
    {
        var dirTo = (targetPos - transform.position).normalized;

        bool tildIsDone = true;

        if (_lookPoint != null)
        {
            tildIsDone = _lookPoint.LeanedTo(dirTo);
        }
        
        var turnIsDone = TurnTo(dirTo);

        return turnIsDone && tildIsDone;

    }

    public bool TurnTo(Vector3 dirTo)
    {       
        return _npcMover.TurnTo(dirTo);
    }

    protected void OnAttacking()
    {
        onAttacking?.Invoke();
    }

    public override void GetDamage(float damage, Character attacker)
    {
        base.GetDamage(damage, attacker);

        if (Target == null)
        {
            Target = attacker as Player;
        }
    }

    public override void Deth()
    {
        StopMove();
        base.Deth();
    }
}
