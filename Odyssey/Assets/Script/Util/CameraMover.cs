using UnityEngine;

public class CameraMover : MonoBehaviour
{
    GameObject player;
    [SerializeField] float speed = 5f;
    [SerializeField] float yFollowSpeed = 2f;

    private void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
    }

    private void FixedUpdate()
    {
        // 이동 속도로 오른쪽으로 이동
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // 플레이어의 y 위치를 따라 카메라의 y 위치 변경
        float newYPosition = Mathf.Lerp(transform.position.y, player.transform.position.y, yFollowSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }
}