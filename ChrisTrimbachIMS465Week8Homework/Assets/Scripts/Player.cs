using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody rigid = null;
    private GameObject head = null;
    private Camera mainCamera = null;

    [SerializeField] private float moveSpeed = 1f;

    private Vector3 currentVelocity = new Vector3();
    private float LookX = 0f;
    private float LookY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
        head = GameObject.FindGameObjectWithTag("Head");
        mainCamera = this.GetComponentInChildren<Camera>();
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

    public void OnMove(InputValue value)
    {
        currentVelocity = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
    }

    private void Movement()
    {
        rigid.MovePosition(transform.position + currentVelocity * moveSpeed);
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
    }

    public void OnFire(InputValue value)
    {

    }
}
