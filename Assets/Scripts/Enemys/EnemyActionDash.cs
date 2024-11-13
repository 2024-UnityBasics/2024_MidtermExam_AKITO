using UnityEngine;
using System.Collections;

public class EnemyActionDash : MonoBehaviour
{
    [SerializeField] Transform target;              // Playerの位置を指定
    [SerializeField] float dashSpeed = 10f;         // 一定の突進速度
    [SerializeField] float dashDuration = 1f;       // 突進の効果時間
    [SerializeField] float dashCooldown = 2f;       // 突進後の待機時間

    private bool isDashing = false;       // 突進中かどうか
    private Rigidbody rb;                 // Rigidbodyコンポーネント
    private Vector3 dashDirection;        // 突進の方向

    void Start()
    {
        // Rigidbodyコンポーネントの取得
        rb = GetComponent<Rigidbody>();

        // 追尾対象の取得（Playerを想定）
        target = GameObject.Find("Player").GetComponent<Transform>();
        StartCoroutine(EnemyDashRoutine());
    }

    private IEnumerator EnemyDashRoutine()
    {
        while (true)
        {
            if (!isDashing)
            {
                StartDash(); // 突進を開始

                // 突進中の処理
                float dashEndTime = Time.time + dashDuration; // 突進終了の時間を計算

                // 突進が終了するまで、速度を固定して突進する
                while (Time.time < dashEndTime)
                {
                    rb.velocity = dashDirection * dashSpeed; // 突進方向に一定の速度で進む
                    yield return null; // 次のフレームへ
                }

                // 突進終了後、速度を0にする
                rb.velocity = Vector3.zero;
                isDashing = false; // 突進が終了したのでフラグをリセット
                yield return new WaitForSeconds(dashCooldown); // 待機時間を設ける
            }
        }
    }

    void StartDash()
    {
        // プレイヤーの方向を向き、突進方向を計算
        transform.LookAt(target.position);
        dashDirection = (target.position - transform.position).normalized; // 突進の方向を一度だけ取得
        isDashing = true; // 突進中フラグを立てる
    }
}
