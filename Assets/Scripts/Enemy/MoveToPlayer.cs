using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    Transform playerTransform;

    private void Start()
    {
        playerTransform = PlayerMovement.Instance.transform;
    }



    private void FixedUpdate()
    {
        transform.Translate((playerTransform.position - transform.position).normalized * moveSpeed * Time.fixedDeltaTime);
    }

}
