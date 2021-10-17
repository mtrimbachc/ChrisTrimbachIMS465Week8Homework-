using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody rigid = null;
    private GameObject head = null;
    private Camera mainCamera = null;
    private CharacterController controller = null;

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float sensitivity = 1f;

    private Vector3 currentVelocity = new Vector3();
    private float LookX = 0f;
    private float LookY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        head = GameObject.FindGameObjectWithTag("Head");
        mainCamera = this.GetComponentInChildren<Camera>();
        controller = this.GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Look();
        Movement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBack(InputValue value)
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnMove(InputValue value)
    {
        currentVelocity = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
        currentVelocity.y -= 0.981f;
    }

    private void Movement()
    {
        controller.Move(transform.TransformDirection(currentVelocity * moveSpeed));
    }

    public void OnLook(InputValue value)
    {
        LookX = value.Get<Vector2>().x;
        LookY = value.Get<Vector2>().y;
    }

    private void Look()
    {
        Vector3 newLookX = transform.localEulerAngles;
        Vector3 newLookY = head.transform.localEulerAngles;

        newLookX.y += LookX * sensitivity;
        newLookY.x -= LookY * sensitivity;

        // Prevents clipping
        if (newLookY.x >= 90 && newLookY.x < 180)
            newLookY.x += LookY * sensitivity;

        if (newLookY.x <= 270 && newLookY.x > 180)
            newLookY.x += LookY * sensitivity;

        transform.localEulerAngles = newLookX;
        head.transform.localEulerAngles = newLookY;

    }

    public void OnFire(InputValue value)
    {

    }
}
