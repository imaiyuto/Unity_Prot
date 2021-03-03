using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsDisplay : MonoBehaviour
{
    // 変数
    int frameCount;
    float prevTime;
    float fps;


    // Start is called before the first frame update
    void Start()
    {
        frameCount = 0;
        prevTime = 0.0f;
    }

    void Awake()
    {
        Application.targetFrameRate = -1;
    }

    // Update is called once per frame
    void Update()
    {
        frameCount++;
        float time = Time.realtimeSinceStartup - prevTime;

        if (time >= 0.5f)
        {
            fps = frameCount / time;
            Debug.Log(fps);

            frameCount = 0;
            prevTime = Time.realtimeSinceStartup;
        }
    }
}
