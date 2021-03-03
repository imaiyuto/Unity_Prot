using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerCnt : MonoBehaviour
{

    public GameObject PowerCnt_object = null;
    public GameObject JumpCnt_object = null;//★

    GameObject Player; // Playerそのものが入る変数

    Move Mv;            // C#スクリプト"Move.cs"が入る変数

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player"); //Fieldを("〇〇")の名前から取得して変数に格納する。(tagではない。)
        Mv = Player.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {

        Text power_text = PowerCnt_object.GetComponent<Text>();
        Text jump_text = JumpCnt_object.GetComponent<Text>();
        // テキストを変更
        power_text.text = "パワー : " + Mv.power_cnt;
        jump_text.text = "ジャンプ可能回数 : " + Mv.jump_cnt;

    }
}
