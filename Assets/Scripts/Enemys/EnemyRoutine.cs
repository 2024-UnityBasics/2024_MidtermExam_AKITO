using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRutine : MonoBehaviour
{
    Transform target;

    [SerializeField] float swayAmplitude = 0.5f;   // 揺れの振幅
    [SerializeField] float swayFrequency = 1f;     // 揺れの速さ
    Vector3 initialPosition;                       // 初期の位置
    Rigidbody rb;

    void Start()
    {
        // Rigidbody コンポーネントの取得
        rb = GetComponent<Rigidbody>();

        // 追尾対象の取得（Playerを想定）
        target = GameObject.Find("Player").GetComponent<Transform>();

        // 初期位置を記録
        initialPosition = transform.position;
    }

    void Update()
    {
        // プレイヤーの方向を向く
        transform.LookAt(target.position);

        // ローカル座標系でのゆらゆら動作を追加
        float swayX = Mathf.Sin(Time.time * swayFrequency) * swayAmplitude;  // 左右の揺れ
        float swayZ = Mathf.Cos(Time.time * swayFrequency) * swayAmplitude;  // 前後の揺れ

        // 初期位置に揺れを加えた位置を計算
        Vector3 targetPosition = initialPosition + new Vector3(swayX, 0, swayZ);

        // Rigidbodyでの位置更新
        rb.MovePosition(targetPosition);
    }
}
