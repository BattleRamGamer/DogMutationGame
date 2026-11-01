using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    [SerializeField] private float dashMultiplier;

    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashTimeActive;

    private float dashTimer;

    bool wantsToDash = false;


    Rigidbody rb;


    Vector2 moveInput;

    Vector3 moveVector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }





    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
    }

    private void FixedUpdate()
    {
        float moveMultiplier = movementSpeed;
        if (wantsToDash)
        {
            if (dashTimer <= 0)
            {
                // Activate dash
                dashTimer = dashCooldown;
            }


            wantsToDash = false;
        }

        if (dashTimer > 0)
        {

            if (dashTimer + dashTimeActive > dashCooldown)
            {
                // Dash is active
                moveMultiplier *= dashMultiplier;
            }
            else
            {
                // Dash is not active
            }


            dashTimer -= Time.fixedDeltaTime;

        }



        transform.Translate(new Vector3(moveInput.x, 0, moveInput.y) * Time.fixedDeltaTime * moveMultiplier);
        //rb.AddForce(moveInput.x, 0, moveInput.y);
    }

    private void GetMovementInput()
    {
        moveInput = InputSystem.actions["move"].ReadValue<Vector2>();
        wantsToDash = InputSystem.actions["Sprint"].WasPressedThisFrame();
    }



}
