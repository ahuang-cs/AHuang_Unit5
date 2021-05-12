using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float minForce = 10f;
    public float maxForce = 15f;
    public float minTorque = -10f;
    public float maxTorque = 10f;
    public int pointValue;
    public ParticleSystem destroyParticleSystem;

    private const float minXPos = -3f;
    private const float maxXPos = 3f;
    private const float yPos = -2f;

    private Rigidbody rb;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
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

    public void DestroyTarget()
    {
        Instantiate(destroyParticleSystem, transform.position, destroyParticleSystem.transform.rotation);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if (!gm.IsGameOver())
        {
            gm.AddToScore(pointValue);
            DestroyTarget();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Hazard"))
        {
            gm.GameOver();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
