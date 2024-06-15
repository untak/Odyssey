using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    #region Singleton
    private static GameScene instance;
    public static GameScene Instance
    {
        get { return instance; }
    }
    #endregion

    [SerializeField] StageGimmick stageGimmick;
    [SerializeField] public bool canDoubleJump = false;
    [SerializeField] public bool canDash = false;
    [SerializeField] public bool canAddHp = false;

    private void Awake()
    {
        if(instance == null)
        {
        instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance !=  this)
        {
            Destroy(this.gameObject);
        }
    }
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
        DisableShadows();
    }

    void DisableShadows()
    {
        // 그림자 제거
        Light[] lights = FindObjectsOfType<Light>();

        foreach (Light light in lights)
        {
            light.shadows = LightShadows.None;
        }
    }
}
