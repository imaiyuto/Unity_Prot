using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldRotate : MonoBehaviour
{
    float Rot_Add;                  // 回転角度の加算分
    float Rot_Base;                 // 回転のベース(180°ずつ加算)
    public bool Rotation;           // 回転フラグ
    [Header("1秒の回転角度")] public int Rot_Speed;
    [Header("1回の回転角度")] public int Rot_Max;
    // Start is called before the first frame update
    void Start()
    {
        Rotation = false;
        Rot_Add = 0.0f;
        Rot_Base = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            Rotation = true;
        }

        if (Rotation)
        {
            Rot_Add += Rot_Speed * Time.deltaTime;

            if(Rot_Add >= Rot_Max)
            {
                Rot_Base += Rot_Max;
                Rotation = false;
                Rot_Add = 0;
            }

            // transformを取得
            Transform myTransform = this.transform;

            // ローカル座標を基準に、回転を取得
            Vector3 localAngle = myTransform.localEulerAngles;
            localAngle.x = 0.0f;       // ローカル座標を基準に、x軸を軸にした回転を10度に変更
            localAngle.y = 0.0f;                        // ローカル座標を基準に、y軸を軸にした回転を10度に変更
            localAngle.z = -(Rot_Add + Rot_Base);                        // ローカル座標を基準に、z軸を軸にした回転を10度に変更
            myTransform.localEulerAngles = localAngle;  // 回転角度を設定
        }
    }
}
