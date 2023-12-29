using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundedState : PlayerBaseState
{
    public PlayerGroundedState(PlayerStateMachine PlayerStateMachine) : base(PlayerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.GroundParameterHash); // GroundParameterHash ������ StartAnimation �޼��� ������ bool ���� true�� �����.
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.GroundParameterHash); // bool ���� false�� �����.
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.IsAttacking)
        {
            OnAttack();
            return;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    protected override void OnMovementCanceled(InputAction.CallbackContext context)
    {
        if(stateMachine.MovementInput == Vector2.zero) // �Է��� ���ٸ�
        {
            return;
        }

        stateMachine.ChangeState(stateMachine.IdleState); // Idle ���°� ������.

        base.OnMovementCanceled(context);
    }

    protected virtual void OnMove()
    {
        stateMachine.ChangeState(stateMachine.WalkState);
    }
    protected virtual void OnAttack()
    {
        stateMachine.ChangeState(stateMachine.AttackState);
    }
    protected override void OnInteraction(InputAction.CallbackContext context)
    {
        Debug.Log("f");
    }

}
