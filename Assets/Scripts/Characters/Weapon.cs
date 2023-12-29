using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Collider myCollider;

    private int damage;
    private float knockback;
    [Header("Resource Gathering")]
    public bool doesGatherResources;
    // private Camera camera;

    private List<Collider> alreadyColliderWith = new List<Collider>(); // ��� collider���� ���� Ŭ����

    //private void Awake()
    //{
    //    camera = Camera.main;
    //}
    private void OnEnable()
    {
        alreadyColliderWith.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        //RaycastHit hit;
        // �ó׸ӽſ��� ����ĳ��Ʈ�� �޸����� �ʾƼ� ���� ī�޶�� ������ ������ ���� �浹 �� �ó׸ӽſ��� ����ī�޶�� ������ �̵��ϴ� �̽��� �־ ���!

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

        GatherResource(other);
    }

    public void SetAttack(int damage, float knockback)
    {
        this.damage = damage;
        this.knockback = knockback;
    }

    public void GatherResource(Collider other)
    {
        if (doesGatherResources) // �ڿ� ä�� �����Ѱ� bool ������ �Ǵ�!
        {
            if (other.TryGetComponent(out Resource resource))
            {
                Vector3 pos = new Vector3(1, 3, 0);
                Vector3 direction = myCollider.transform.position + pos; // �÷��̾��� �Ӹ� ������ �����ǰ�. . . �ʹ� �ָԱ����� �ƽ���.
                Vector3 hitNormal = other.transform.up; // ������ ������ �������� normal�� ���� ��� �ϴµ� �������� �ڵ带 �־���... �ϴ� �۵��� �ȴ�;
                resource.Gather(direction, hitNormal);
            }
        }        
    }
}
