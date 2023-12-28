using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    // PlayerStateMachine�� ����� �������� �ۼ�
    public Enemy Enemy { get; }

    public Health Target { get; private set; }
    
    public EnemyIdleState IdlingState { get; }
    public EnemyChasingState ChasingState { get; }
    public EnemyAttackState AttackState { get; }

    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;

    public EnemyStateMachine(Enemy enemy)
    {
        Enemy = enemy;
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>(); // Player �±׸� �i�ư���.

        IdlingState = new EnemyIdleState(this);
        ChasingState = new EnemyChasingState(this);
        AttackState = new EnemyAttackState(this);

        MovementSpeed = enemy.Data.GroundedData.BaseSpeed; // PlayerGroundedState ����
        RotationDamping = enemy.Data.GroundedData.BaseRotationDamping; // PlayerGroundedState ����
    }
}
