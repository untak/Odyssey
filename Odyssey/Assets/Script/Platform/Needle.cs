using UnityEngine;

public class Needle : MonoBehaviour
{
    [SerializeField] BoxCollider hitBox;

    private void Start()
    {
        hitBox.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Define.PlayerTag))
        {
            Debug.Log("Player");
        }
    }
}