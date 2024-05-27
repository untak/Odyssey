using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<InputManager>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("@InputManager");
                    _instance = singletonObject.AddComponent<InputManager>();
                }
            }   
            DontDestroyOnLoad(_instance.gameObject);
            return _instance;
        }
    }

    [Header("ÀÔ·ÂÅ°")]
    [SerializeField] KeyCode leftMove = KeyCode.LeftArrow;
    [SerializeField] KeyCode rightMove = KeyCode.RightArrow;
    [SerializeField] KeyCode jump = KeyCode.Z;
    [SerializeField] KeyCode attack = KeyCode.X;
    [SerializeField] KeyCode dash = KeyCode.C;

    private bool _isLeftMove = false;
    private bool _isRightMove = false;
    private bool _isJump = false;
    private bool _isVariableJump = false;
    private bool _isAttack = false;
    private bool _isDash = false;

    public bool IsLeftMove
    {
        get { return _isLeftMove; }
        private set { _isLeftMove = value; }
    }
    public bool IsRightMove
    {
        get { return _isRightMove; }
        private set { _isRightMove = value; }
    }
    public bool IsJump
    {
        get { return _isJump; }
        private set { _isJump = value; }
    }
    public bool IsVariableJump
    {
        get { return _isVariableJump; }
        private set { _isVariableJump = value; }
    }
    public bool IsAttack
    {
        get { return _isAttack; }
        private set { _isAttack = value; }
    }
    public bool IsDash
    {
        get { return _isDash; }
        private set { _isDash = value; }
    }

    private void Update()
    {
        IsLeftMove = Input.GetKey(leftMove);
        IsRightMove = Input.GetKey(rightMove);
        IsJump = Input.GetKey(jump);
        IsAttack = Input.GetKeyDown(attack);
        IsDash = Input.GetKeyDown(dash);
    }
}
