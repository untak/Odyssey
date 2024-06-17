using UnityEngine;
using UnityEngine.UI;

public class Hp_UI : MonoBehaviour
{
    [SerializeField] float hpLayout_width;

    [Header("==========")]
    [SerializeField] RectTransform Hp_BackGround;
    [SerializeField] Image[] hpImages;
    [SerializeField] Sprite[] hpCircle_Images3;
    [SerializeField] Sprite[] hpCircle_Images5;
    [SerializeField] Sprite hp_Unfilled;
    [SerializeField] Image hpCircle;

    Sprite[] currentSprites;
    int currentIndex = 0;

    void Start()
    {
        // hp 5칸일 경우
        if(GameScene.Instance.canAddHp)
        {
            Hp_BackGround.sizeDelta = new Vector2(hpLayout_width, Hp_BackGround.sizeDelta.y);
            hpImages[3].gameObject.SetActive(true);
            hpImages[4].gameObject.SetActive(true);
            currentSprites = hpCircle_Images5;
            hpCircle.sprite = currentSprites[currentIndex];
        }
        else
        {
            hpImages[3].gameObject.SetActive(false);
            hpImages[4].gameObject.SetActive(false);
            currentSprites = hpCircle_Images3;
            hpCircle.sprite = currentSprites[currentIndex];
        }
    }
    public void SetHp_UI(int damage)
    {
        int damageCount = damage;
        // 배열의 마지막 인덱스부터 시작해서 역순으로 검사
        for (int i = currentSprites.Length - 2; i >= 0; i--)
        {
            // 해당 오브젝트가 활성화되어 있다면
            if (hpImages[i].sprite != hp_Unfilled)
            {
                // 오브젝트 비활성화
                hpImages[i].sprite = hp_Unfilled;

                // damage를 하나 감소
                damageCount--;

                // 비활성화할 오브젝트 수가 0이 되면 함수 종료
                if (damageCount == 0)
                {
                    break;
                }
            }
        }

        currentIndex = (currentIndex + damage) % currentSprites.Length;
        hpCircle.sprite = currentSprites[currentIndex];
    }
}
