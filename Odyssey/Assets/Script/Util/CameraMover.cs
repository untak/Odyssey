using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
