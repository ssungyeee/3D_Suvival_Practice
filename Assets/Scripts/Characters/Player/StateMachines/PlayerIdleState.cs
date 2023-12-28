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
        // Idle 상태에선 가만히 있어야 하기 때문에 움직임 값을 0으로
        stateMachine.MovementSpeedModifier = 0f;
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.IdleParameterHash); // IdleParameterHash 값으로 StartAnimation 메서드 내부의 bool 값을 true로 만든다.
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.IdleParameterHash); // bool 값을 false로 만든다.
    }

    public override void Update()
    {
        base.Update();

        if(stateMachine.MovementInput != Vector2.zero) // 이동하는 값이 입력 되었다면
        {
            OnMove(); // GroundedState에서 만들어 놓은 메서드, Idle -> Walk 로 상태를 바꾼다.
            return;
        }
    }
}
