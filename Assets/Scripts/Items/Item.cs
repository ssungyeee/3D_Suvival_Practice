using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public void OnDestroyItem()
    {
        // �浹 ó���� �� �Ǵ� ���� Ȯ�� ������ ���� ������ ȹ�� �ڵ带 ¥����.
        Destroy(gameObject);
    }
}
