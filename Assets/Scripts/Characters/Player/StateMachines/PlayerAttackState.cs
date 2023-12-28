using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    private bool alreadyAppliedForce;
    private bool alreadyAppliedDealing;

    AttackInfoData attackInfoData;
    public PlayerAttackState(PlayerStateMachine PlayerStateMachine) : base(PlayerStateMachine)
    {
    }
    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0;
        base.Enter();

        alreadyAppliedForce = false;
        alreadyAppliedDealing = false;

        int attackIndex = stateMachine.AttackIndex;

        attackInfoData = stateMachine.Player.Data.AttackData.GetAttackInfo(attackIndex);
        StartAnimation(stateMachine.Player.AnimationData.AttackParameterHash);
    }

    public override void Exit()
    {
        base.Exit();

        StopAnimation(stateMachine.Player.AnimationData.AttackParameterHash);
    }


    public override void Update()
    {
        base.Update();

        ForceMove();


        float normalizedTime = GetNormalizedTime(stateMachine.Player.Animator, "Attack");

        if (normalizedTime < 1f)
        {
            if (normalizedTime >= stateMachine.Player.Data.AttackData.AttackInfoDatas[0].ForceTransitionTime)
            {
                TryApplyForce();
            }
            if (!alreadyAppliedDealing && normalizedTime >= stateMachine.Player.Data.AttackData.AttackInfoDatas[0].Dealing_Start_TransitionTime) // 데미지를 넣는 중이 아니라면 콜라이더를 켜준다
            {
                stateMachine.Player.Weapon.SetAttack(stateMachine.Player.Data.AttackData.AttackInfoDatas[0].Damage, stateMachine.Player.Data.AttackData.AttackInfoDatas[0].Force);
                stateMachine.Player.Weapon.gameObject.SetActive(true);
                alreadyAppliedDealing = true;
            }
            if (alreadyAppliedDealing && normalizedTime >= stateMachine.Player.Data.AttackData.AttackInfoDatas[0].Dealing_End_TransitionTime) // 데미지를 넣는 중이라면 콜라이더를 꺼준다
            {
                stateMachine.Player.Weapon.gameObject.SetActive(false);
            }
        }
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void TryApplyForce()
    {
        if (alreadyAppliedForce) return;
        alreadyAppliedForce = true;

        stateMachine.Player.ForceReceiver.Reset();

        stateMachine.Player.ForceReceiver.AddForce(stateMachine.Player.transform.forward * attackInfoData.Force);
    }
}
