using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGenerator : MonoBehaviour
{
    private GameObject roads;
    private Rigidbody rigidbodyPlayer;
    public bool isGrounded = false;

    private float lPos = -0.2f;
    private float rPos = 0.2f;

    void Start()
    {
        roads = GameObject.FindGameObjectWithTag("Roads");
        rigidbodyPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MovePlayer(float pos)
    {
        if (transform.position.x != pos)
        {
            transform.position = new Vector3(pos, transform.position.y, transform.position.z);
        }
    }

    public void Jump()
    {
        rigidbodyPlayer.AddForce(0f, 150f, 0f, ForceMode.Force);
        isGrounded = false;
    }

    public void MoveRoad(int a)
    {
        roads.transform.rotation *= Quaternion.Euler(0f, 0f, a * 90f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}
