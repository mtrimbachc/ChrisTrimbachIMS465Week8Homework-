using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPusher : MonoBehaviour
{
    private float timeToMove = 2f;
    [SerializeField] private float moveSpeed = 1f;

    private float yPos = 0f;
    private Vector3 moveDir = Vector3.back;
    private Rigidbody rigid = null;

    // Start is called before the first frame update
    void Start()
    {
        yPos = transform.position.y;
        rigid = this.GetComponent<Rigidbody>();
        StartCoroutine(MoveSouth());

        rigid.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 basePos = new Vector3(rigid.transform.position.x, yPos, rigid.transform.position.z);

        rigid.MovePosition(basePos + moveDir * moveSpeed);
    }

    private IEnumerator MoveSouth()
    {
        moveDir = Vector3.back;
        yield return new WaitForSeconds(timeToMove);
        StartCoroutine(MoveEast());
    }

    private IEnumerator MoveWest()
    {
        moveDir = Vector3.right;
        yield return new WaitForSeconds(timeToMove);
        StartCoroutine(MoveSouth());
    }

    private IEnumerator MoveNorth()
    {
        moveDir = Vector3.forward;
        yield return new WaitForSeconds(timeToMove);
        StartCoroutine(MoveWest());
    }

    private IEnumerator MoveEast()
    {
        moveDir = Vector3.left;
        yield return new WaitForSeconds(timeToMove);
        StartCoroutine(MoveNorth());
    }


}
