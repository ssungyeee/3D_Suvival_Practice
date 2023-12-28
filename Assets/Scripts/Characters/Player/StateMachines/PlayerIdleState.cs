using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerStateMachine PlayerStateMachine) : base(PlayerStateMachine)
    {
    }

    public override void Enter()
    {
        // Idle ���¿��� ������ �־�� �ϱ� ������ ������ ���� 0����
        stateMachine.MovementSpeedModifier = 0f;
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.IdleParameterHash); // IdleParameterHash ������ StartAnimation �޼��� ������ bool ���� true�� �����.
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.IdleParameterHash); // bool ���� false�� �����.
    }

    public override void Update()
    {
        base.Update();

        if(stateMachine.MovementInput != Vector2.zero) // �̵��ϴ� ���� �Է� �Ǿ��ٸ�
        {
            OnMove(); // GroundedState���� ����� ���� �޼���, Idle -> Walk �� ���¸� �ٲ۴�.
            return;
        }
    }
}
