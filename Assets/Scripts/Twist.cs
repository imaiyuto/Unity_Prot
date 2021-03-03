using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]

public class Twist : MonoBehaviour
{

    public Vector3 axis = new Vector3(0, 0, 1);     // 多分、軸
    int angle;        // 多分、角度
    public int maxangle;    // 最大角度

    GameObject Cubes; //Cubesそのものが入る変数

    FieldRotate Fr;     // C#スクリプト"FieldRotate"が入る変数

    bool is_Twist;
    bool is_Player_Forward;

    MeshFilter meshFilter;
    private Vector3[] originalVerts;
    private Vector3[] newVerts;

    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        originalVerts = meshFilter.mesh.vertices;
        newVerts = new Vector3[originalVerts.Length];

        Cubes = GameObject.Find("Cube's"); //Fieldを("〇〇")の名前から取得して変数に格納する。(tagではない。)

        Fr = Cubes.GetComponent<FieldRotate>();     // GetComponent しておく
        angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        is_Twist = Fr.Rotation;

        if(is_Twist && is_Player_Forward)
        {
            angle++;

            if(angle >= maxangle)
            {
                angle = maxangle;
                maxangle += 180;
            }

            //i < originalVerts.Length
            for (int i = 0;  i < originalVerts.Length; i++)
            {
                newVerts[i] = Quaternion.Euler(axis * angle * originalVerts[i].z) * originalVerts[i];
            }
            meshFilter.mesh.vertices = newVerts;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Tagの Field_01, Cube_01 と当たってればジャンプできるよ
        if (collision.gameObject.CompareTag("Player_Forward"))
        {
            is_Player_Forward = true;
        }
        else
        {
            is_Player_Forward = false;
        }
    }

}
