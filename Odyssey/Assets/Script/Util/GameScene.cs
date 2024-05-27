using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    StageGimmick stageGimmick;
    void Update()
    {
        stageGimmick.Excute();
    }
}
