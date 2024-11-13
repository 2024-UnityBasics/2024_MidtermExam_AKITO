using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    [SerializeField] string tagName;            //当たり判定となるタグ
    private StatusManager statusManager;

    void Start()
    {
        // 親オブジェクトの StatusManager を取得
        statusManager = GetComponentInParent<StatusManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // 指定されたタグと一致するオブジェクトと接触した場合
        if (other.CompareTag(tagName))
        {
            Debug.Log("Hit registered by DamageTrigger");

            // 親の StatusManager にダメージを通知
            if (statusManager != null)
            {
                statusManager.Damage();
            }
        }
    }
}
