public class Player : Entity
{
    PlayerMovement playermovement;

    private void Awake()
    {
        base.RigidbodyInit();
    }

    private void Start()
    {
        if(GetComponent<PlayerMovement>() == null)
        {
            playermovement = gameObject.AddComponent<PlayerMovement>();
        }
    }
}
