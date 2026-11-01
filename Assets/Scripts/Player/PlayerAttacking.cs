using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacking : MonoBehaviour
{

    [SerializeField] private GameObject attackPrefab;




    private void Update()
    {
        if (InputSystem.actions["attack"].WasPressedThisFrame())
        {

            Instantiate(attackPrefab, transform);


        }
    }



}
