using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{
    [SerializeField] private string groundParameterName = "@Ground";
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string walkParameterName = "Walk";

    [SerializeField] private string attackParameterName = "@Attack";
    [SerializeField] private string enemyAttackParameterName = "EnemyAttack";


    public int GroundParameterHash {  get; private set; }
    public int IdleParameterHash { get; private set; }
    public int WalkParameterHash { get; private set; }

    public int AttackParameterHash { get; private set; }
    public int EnemyAttackParameterHash { get; private set; }


    // ������ ���� string ���� �ٷ� ���ϴ� ���� �ƴ� Hash ������ ��ȯ�Ͽ� ��
    public void Initialize()
    {
        GroundParameterHash = Animator.StringToHash(groundParameterName);
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        WalkParameterHash = Animator.StringToHash(walkParameterName);
        EnemyAttackParameterHash = Animator.StringToHash(enemyAttackParameterName);

        AttackParameterHash = Animator.StringToHash(attackParameterName);
    }
}
