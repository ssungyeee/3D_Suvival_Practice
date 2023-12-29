using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public void OnDestroyItem()
    {
        // 충돌 처리가 잘 되는 것을 확인 했으니 이제 아이템 획득 코드를 짜보자.
        Destroy(gameObject);
    }
}
