using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    Rigidbody rb;       // Rigidbody の変数
    GameObject Field; //Fieldそのものが入る変数

    FieldRotate Fr;     // C#スクリプト"FieldRotate"が入る変数

    public float power_cnt;     // ジャンプのパワーカウント
    public int jump_cnt;        //ジャンプ可能回数を記録★
    public float jump_speed;    //ジャンプの速さ★ 
    bool charge;                // 回転フラグみたいなもん。
    bool is_Jump;               // ジャンプしているかどうか
    Vector3 forceDirection;     //★

    // Start is called before the first frame update
    void Start()
    {
        power_cnt = 1;      // 初期状態のパワーは 1
        jump_cnt = 0;

        rb = GetComponent<Rigidbody>();     // GetComponent しておく

        Field = GameObject.Find("Cube's"); //Fieldを("〇〇")の名前から取得して変数に格納する。(tagではない。)

        Fr = Field.GetComponent<FieldRotate>();     // GetComponent しておく

        GetComponent<Renderer>().material.color = Color.blue;   // プレイヤーの初期状態の色(青)

        is_Jump = true;     // 最初は浮いているから true。
    }

    // Update is called once per frame
    void Update()
    {
        bool charge = Fr.Rotation;      // FieldRotation.cs の bool Rotationを持ってくる。

        // 移動
        if (Input.GetKey(KeyCode.D) && !is_Jump)    // 全身
        {
            transform.position += transform.forward * 0.01f;
        }
        if (Input.GetKey(KeyCode.A) && !is_Jump)    // 後退
        {
            transform.position -= transform.forward * 0.01f;
        }



        // ジャンプ
        if (!is_Jump && 1 <= jump_cnt && jump_cnt <= 5)
        {
            if (Input.GetKeyDown(KeyCode.E)) // 前方向へジャンプ
            {

                is_Jump = true;     // ジャンプフラグをtrueに

                // SphereオブジェクトのRigidbodyコンポーネントへの参照を取得
                Rigidbody rb = gameObject.GetComponent<Rigidbody>();

                rb.velocity = Vector3.zero;//★

                // 力を加える向きをVector3型で定義
                forceDirection = new Vector3(0.0f, 0.5f, 0.25f);

                // 上の向きに加わる力の大きさを定義
                float forceMagnitude = jump_speed * power_cnt;//★

                // 向きと大きさからSphereに加わる力を計算する
                Vector3 force = forceMagnitude * forceDirection;


                // 力を加えるメソッド
                // ForceMode.Impulseは撃力
                rb.AddForce(force, ForceMode.Impulse);

                power_cnt = 1;  // ジャンプしたらパワーカウントを元に戻す
                jump_cnt -= 1;  //ジャンプ可能回数を1減らす

                is_Jump = false;     // ジャンプフラグをfalseに
            }
            else if (Input.GetKeyDown(KeyCode.Q))    // 後ろ方向へジャンプ
            {
                is_Jump = true;     // ジャンプフラグをtrueに

                // SphereオブジェクトのRigidbodyコンポーネントへの参照を取得
                Rigidbody rb = gameObject.GetComponent<Rigidbody>();

                rb.velocity = Vector3.zero;//★

                // 力を加える向きをVector3型で定義
                forceDirection = new Vector3(0.0f, 0.5f, -0.25f);

                // 上の向きに加わる力の大きさを定義
                float forceMagnitude = jump_speed * power_cnt;

                // 向きと大きさからSphereに加わる力を計算する
                Vector3 force = forceMagnitude * forceDirection;


                // 力を加えるメソッド
                // ForceMode.Impulseは撃力
                rb.AddForce(force, ForceMode.Impulse);

                power_cnt = 1;      // ジャンプしたらパワーカウントを元に戻す
                jump_cnt -= 1;  //ジャンプ可能回数を1減らす

                is_Jump = false;     // ジャンプフラグをfalseに★

            }
            else if (Input.GetKeyDown(KeyCode.W)) // 上方向へジャンプ
            {
                is_Jump = true;     // ジャンプフラグをtrueに

                // SphereオブジェクトのRigidbodyコンポーネントへの参照を取得
                Rigidbody rb = gameObject.GetComponent<Rigidbody>();

                rb.velocity = Vector3.zero;//★

                // 力を加える向きをVector3型で定義
                forceDirection = new Vector3(0.0f, 0.5f, 0f);

                // 上の向きに加わる力の大きさを定義
                float forceMagnitude = jump_speed * power_cnt;//★

                // 向きと大きさからSphereに加わる力を計算する
                Vector3 force = forceMagnitude * forceDirection;


                // 力を加えるメソッド
                // ForceMode.Impulseは撃力
                rb.AddForce(force, ForceMode.Impulse);

                power_cnt = 1;  // ジャンプしたらパワーカウントを元に戻す
                jump_cnt -= 1;  //ジャンプ可能回数を1減らす

                is_Jump = false;     // ジャンプフラグをfalseに
            }
            else if (Input.GetKeyDown(KeyCode.S))    // 下方向へジャンプ
            {
                is_Jump = true;     // ジャンプフラグをtrueに

                // SphereオブジェクトのRigidbodyコンポーネントへの参照を取得
                Rigidbody rb = gameObject.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;//★


                // 力を加える向きをVector3型で定義
                forceDirection = new Vector3(0.0f, -0.5f, 0f);

                // 上の向きに加わる力の大きさを定義
                float forceMagnitude = jump_speed * power_cnt;

                // 向きと大きさからSphereに加わる力を計算する
                Vector3 force = forceMagnitude * forceDirection;

                // 力を加えるメソッド
                // ForceMode.Impulseは撃力
                rb.AddForce(force, ForceMode.Impulse);

                power_cnt = 1;      // ジャンプしたらパワーカウントを元に戻す
                jump_cnt -= 1;  //ジャンプ可能回数を1減らす

                is_Jump = false;     // ジャンプフラグをfalseに★

            }
        }



        if (Input.GetKeyDown(KeyCode.J))
        {
            if (!charge)
            {
                // パワーカウントアップ
                power_cnt += 0.1f;

                if (jump_cnt <= 4)
                {
                    jump_cnt += 1;
                }

            }
        }

        if (charge)
        {
            // 自分自身の色を赤に変える
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            // 自分自身の色を赤に変える
            GetComponent<Renderer>().material.color = Color.blue;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        // Tagの Field_01, Cube_01 と当たってればジャンプできるよ
        if (collision.gameObject.CompareTag("Field_01") || collision.gameObject.CompareTag("Cube_01"))
        {
            is_Jump = false;
        }

        // Tagの Death_01 と当たってればリザルド画面へ
        if (collision.gameObject.CompareTag("Death_01"))
        {
            SceneManager.LoadScene("Result");
        }
    }
}
