using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define : MonoBehaviour
{
    public const string PlayerTag = "Player";

    public enum GimmickPhase_Stage1
    {
        WARNING,
        WAITING,
        LAUNCH,
    }

    public enum LayerMask
    {
        PLAYER = 3,
    }
}
