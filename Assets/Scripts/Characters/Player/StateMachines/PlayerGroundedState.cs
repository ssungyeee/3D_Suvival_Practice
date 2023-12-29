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
        StartAnimation(stateMachine.Player.AnimationData.GroundParameterHash); // GroundParameterHash 값으로 StartAnimation 메서드 내부의 bool 값을 true로 만든다.
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.GroundParameterHash); // bool 값을 false로 만든다.
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
        if(stateMachine.MovementInput == Vector2.zero) // 입력이 없다면
        {
            return;
        }

        stateMachine.ChangeState(stateMachine.IdleState); // Idle 상태가 켜진다.

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
