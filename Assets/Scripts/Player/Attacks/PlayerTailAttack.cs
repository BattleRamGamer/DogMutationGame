using UnityEngine;

public class PlayerTailAttack : MonoBehaviour
{


    [SerializeField] private float rotateDuration;

    [SerializeField] private float rotateAngle;

    private void OnEnable()
    {
        Initialize(GetComponentInParent<PlayerMovement>().LookDirection);

        Invoke(nameof(DestroyThis), rotateDuration);
    }

    public void Initialize(Vector3 pLookRotation)
    {

        float rotationThing = Vector3.SignedAngle(Vector3.forward, pLookRotation, Vector3.up) + 270 - (rotateAngle * .5f);

        transform.Rotate(Vector3.up * rotationThing);

    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up * (Time.fixedDeltaTime * rotateAngle / rotateDuration));        
    }


    private void DestroyThis()
    {
        Destroy(gameObject);
    }


}
