using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float minForce = 10f;
    public float maxForce = 15f;
    public float minTorque = -10f;
    public float maxTorque = 10f;

    private const float minXPos = -3f;
    private const float maxXPos = 3f;
    private const float yPos = -2f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        applyRandomForce();
        applyRandomTorque();
        applyRandomPosition();
    }

    private void applyRandomForce()
    {
        rb.AddForce(Vector3.up * Random.Range(minForce, maxForce), ForceMode.Impulse);
    }
    private void applyRandomTorque()
    {
        rb.AddTorque(Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), ForceMode.Impulse);
    }
    private void applyRandomPosition()
    {
        transform.position = new Vector3(Random.Range(minXPos, maxXPos), yPos);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
