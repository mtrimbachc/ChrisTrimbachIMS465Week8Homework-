using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Vector3 openPos = new Vector3();
    [SerializeField] private Vector3 closePos = new Vector3();
    private Vector3 targetPos = new Vector3();

    private Rigidbody rb = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        closePos = rb.position;
        targetPos = closePos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (rb.position != targetPos)
            rb.MovePosition(targetPos);
    }

    public void Open()
    {
        targetPos = openPos;
    }

    public void Close()
    {
        targetPos = closePos;
    }
}
