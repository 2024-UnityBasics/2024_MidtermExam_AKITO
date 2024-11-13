using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private int currentEnemyCount = 0; // 現在の敵数
    private bool isExplorationPhase = false; // 探索フェーズの制御フラグ

    private void Start()
    {
        // 敵の数を定期的にチェックするコルーチンを開始
        StartCoroutine(CheckEnemyCountRoutine());
    }

    // 敵の数を定期的に確認するコルーチン
    private IEnumerator CheckEnemyCountRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // 1秒ごとに確認（必要に応じて調整）

            // デバッグ用ログ
            Debug.Log("Current Enemy Count: " + currentEnemyCount); // 現在の敵数をログに出力

            // Enemyタグを持つオブジェクトの数を取得(.Lengthで数が取得できる)
            currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (currentEnemyCount <= 0 && !isExplorationPhase)
            {
                isExplorationPhase = true;  // 探索フェーズに切り替え

                Debug.Log("Enemy Clear");   //敵がすべて倒された判定、演出やフェーズ変更等を入れてもよい

            // 敵が再度出現するまで待機
            while (currentEnemyCount <= 0)
            {
                currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length; // 敵の数を再確認
                yield return new WaitForSeconds(1f); // 1秒ごとに再確認
            }
                isExplorationPhase = false; // 再度敵が出現したら探索フェーズを終了
            }
        }
    }
}