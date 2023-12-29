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

    private List<Collider> alreadyColliderWith = new List<Collider>(); // 모든 collider들의 상위 클래스

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
        // 시네머신에는 레이캐스트가 달리지가 않아서 메인 카메라로 쓰려고 했으나 레이 충돌 시 시네머신에서 메인카메라로 시점이 이동하는 이슈가 있어서 취소!

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

        GatherResource(other);
    }

    public void SetAttack(int damage, float knockback)
    {
        this.damage = damage;
        this.knockback = knockback;
    }

    public void GatherResource(Collider other)
    {
        if (doesGatherResources) // 자원 채취 가능한가 bool 값으로 판단!
        {
            if (other.TryGetComponent(out Resource resource))
            {
                Vector3 pos = new Vector3(1, 3, 0);
                Vector3 direction = myCollider.transform.position + pos; // 플레이어의 머리 위에서 생성되게. . . 너무 주먹구구라 아쉽다.
                Vector3 hitNormal = other.transform.up; // 원래는 레이의 법선벡터 normal의 값을 써야 하는데 느낌으로 코드를 넣었다... 일단 작동은 된다;
                resource.Gather(direction, hitNormal);
            }
        }        
    }
}
