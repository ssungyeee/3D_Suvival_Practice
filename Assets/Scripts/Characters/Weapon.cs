using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Collider myCollider;

    private int damage;
    private float knockback;

    private List<Collider> alreadyColliderWith = new List<Collider>(); // ��� collider���� ���� Ŭ����

    private void OnEnable()
    {
        alreadyColliderWith.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollider) // �� �ڽ��̸� �Ѿ��.
        {
            return;
        }

        if (alreadyColliderWith.Contains(other)) // collider�� �����ϰ� ������ �Ѿ��.
        {
            return;
        }

        alreadyColliderWith.Add(other); // ���� ��Ȳ�� �� false��� List�� Add�Ѵ�.

        if (other.TryGetComponent(out Health health)) // Health���� ������ ������ ������ ����
        {
            health.TakeDamage(damage);
        }

        if (other.TryGetComponent(out ForceReceiver forceReceiver)) // Health, ForceReceiver �� �ϳ��� ������ �ִ� ��츦 �����ؼ� ���ǹ��� �����ش�.
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
