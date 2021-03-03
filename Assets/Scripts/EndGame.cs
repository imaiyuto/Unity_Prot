using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Rキーで現在のシーンをリロード  (何故か色が変色するw)
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Prot");
        }

        // Escキーでゲーム終了
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR    // 多分Unityの画面上だとこっち
    UnityEditor.EditorApplication.isPlaying = false;

#else               // ビルド後、exeファイルにしたらこっちな気がする....
            Application.Quit();
#endif
        }
    }
}
