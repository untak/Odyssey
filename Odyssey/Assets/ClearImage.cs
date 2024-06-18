using UnityEngine;
using UnityEngine.UI;

public class ClearImage : MonoBehaviour
{
    [SerializeField] Sprite[] images;
    private void Awake()
    {
        GetComponent<Image>().sprite = images[GameScene.Instance.stage - 1];
    }
}
