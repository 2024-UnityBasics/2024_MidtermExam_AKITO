using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //基本の運動方程式（重力落下）

public class GravityTest : MonoBehaviour
{
    Vector3 acceleration;   // 物体の加速度
    Vector3 velocity;       // 物体の速度
    Vector3 position;       // 物体の位置

    private void Start()
    {
        //物体の初速度
        velocity = Vector3.zero;
        //物体の初期位置
        position = transform.position;
    }
    void Update()
    {
        acceleration = Vector3.zero; // 加速度を0にリセット（多重加速させないため）

        //重力加速度(g)を与える
        acceleration += new Vector3(0, -9.8f, 0);

        // 現在の速度を更新
        velocity += acceleration * Time.deltaTime;
        // 現在の位置を更新
        position += velocity * Time.deltaTime;

        // オブジェクトの位置を更新
        transform.position = position;

        /////////////////////////////////
        /// 運動方程式で書くと、
        /// 速度(v) = g * t
        /// もしくは
        /// 落下距離(d) = (1/2) * g * t^2
        /// 上記式はつまり積分なので、Time.deltaTimeごとに逐次足すことで積分と同じ結果が得られる
        /////////////////////////////////
    }
}
