using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private int maxHealth;

    [SerializeField] private int currentHealth;


    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int pDamage)
    {
        currentHealth -= pDamage;
        CheckDeath();

    }

    private void CheckDeath()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.attachedRigidbody.TryGetComponent(out Damage damage))
        {
            TakeDamage(damage.GetDamage());
            Debug.Log("took damage");
        }
    }

}
