using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReceiver : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float drag = 0.3f;

    private Vector3 dampingVelocity;
    private Vector3 impact;
    private float verticalVelocity;

    public Vector3 Movement => impact + Vector3.up * verticalVelocity;

    void Update()
    {
        if (verticalVelocity < 0f && controller.isGrounded) // 땅에 붙어 있는 상태냐
        {
            verticalVelocity = Physics.gravity.y * Time.deltaTime; // 중력 적용
        }
        else
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime; // 땅에 닿도록 중력 계속 추가
        }

        impact = Vector3.SmoothDamp(impact, Vector3.zero, ref dampingVelocity, drag); // 저항값을 가지고 스무스하게 감소 시킨다.
    }

    public void Reset()
    {
        impact = Vector3.zero;
        verticalVelocity = 0f;
    }
    public void AddForce(Vector3 force)
    {
        impact += force;
    }
}
