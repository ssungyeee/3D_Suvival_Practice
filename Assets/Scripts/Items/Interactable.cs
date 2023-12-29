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
        // �����۰� �浹 ó���� Ȯ���Ͽ���.
        if (other.TryGetComponent(out Item item) && other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            // Interaction "F"�� �Է��ϸ� �Ʒ� �Լ��� ����Ǹ� ���ڴµ�. . .
            OnInteractableItem?.Invoke();
            item.OnDestroyItem();
        }
    }

}
