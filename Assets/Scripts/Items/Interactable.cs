using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using System;

public class Interactable : MonoBehaviour
{
    public event Action OnInteractableItem;
    private void OnTriggerEnter(Collider other)
    {
        // 아이템과 충돌 처리를 확인하였다.
        if (other.TryGetComponent(out Item item) && other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            // Interaction "F"를 입력하면 아래 함수가 실행되면 좋겠는데. . .
            OnInteractableItem?.Invoke();
            item.OnDestroyItem();
        }
    }

}
