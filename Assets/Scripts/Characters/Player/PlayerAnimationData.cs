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


    // 성능을 위해 string 값을 바로 비교하는 것이 아닌 Hash 값으로 변환하여 비교
    public void Initialize()
    {
        GroundParameterHash = Animator.StringToHash(groundParameterName);
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        WalkParameterHash = Animator.StringToHash(walkParameterName);
        EnemyAttackParameterHash = Animator.StringToHash(enemyAttackParameterName);

        AttackParameterHash = Animator.StringToHash(attackParameterName);
    }
}
