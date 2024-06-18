using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    #region Singleton
    private static GameScene instance;
    public static GameScene Instance
    {
        get { return instance; }
    }
    #endregion

    [SerializeField] public GameObject stageGimmick;
    [SerializeField] public int stage = 1;
    [SerializeField] public bool canDoubleJump = false;
    [SerializeField] public bool canDash = false;
    [SerializeField] public bool canAddHp = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
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
        if (stageGimmick != null)
        {
            stageGimmick.GetComponent<StageGimmick>().Excute();
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

    public void GoToClearScene()
    {
        SceneManager.LoadScene((int)Define.Scene.CLEAR);
        ++stage;
    }
    public void GoToStageScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == (int)Define.Scene.CLEAR)
        {
            if (Input.anyKeyDown)
            {
                switch (stage)
                {
                    case 2:
                        canDash = true; break;
                    case 3:
                        canDoubleJump = true; break;
                    case 4:
                        canAddHp = true; break;
                    default:
                        break;
                }
                SceneManager.LoadScene(stage);
            }
        }
    }
}
