using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Collider myCollider;

    private int damage;
    private float knockback;

    private List<Collider> alreadyColliderWith = new List<Collider>(); // 모든 collider들의 상위 클래스

    private void OnEnable()
    {
        alreadyColliderWith.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollider) // 나 자신이면 넘어간다.
        {
            return;
        }

        if (alreadyColliderWith.Contains(other)) // collider를 포함하고 있으면 넘어간다.
        {
            return;
        }

        alreadyColliderWith.Add(other); // 위의 상황이 다 false라면 List에 Add한다.

        if (other.TryGetComponent(out Health health)) // Health에서 가져온 값으로 데미지 구현
        {
            health.TakeDamage(damage);
        }

        if (other.TryGetComponent(out ForceReceiver forceReceiver)) // Health, ForceReceiver 중 하나만 가지고 있는 경우를 생각해서 조건문을 나눠준다.
        {
            Vector3 direction = (other.transform.position - myCollider.transform.position).normalized;
            forceReceiver.AddForce(direction * knockback);
        }
    }

    public void SetAttack(int damage, float knockback)
    {
        this.damage = damage;
        this.knockback = knockback;
    }
}
