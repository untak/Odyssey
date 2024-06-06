using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    [SerializeField] StageGimmick stageGimmick;
    private void Start()
    {
        StageInit();
    }
    void Update()
    {
        if(stageGimmick != null)
        {
            stageGimmick.Excute();
        }
    }

    void StageInit()
    {
        // 그림자 제거
        Light[] lights = FindObjectsOfType<Light>();

        foreach (Light light in lights)
        {
            light.shadows = LightShadows.None;
        }
    }
}
