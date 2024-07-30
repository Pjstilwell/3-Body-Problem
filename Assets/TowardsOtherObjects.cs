using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class TowardsOtherObjects : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Rigidbody2D rb2;
    [SerializeField] Rigidbody2D rb3;
    Random random = new Random();

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(GetRandomNumber(-5,5), GetRandomNumber(-5,5));
    }

    // Update is called once per frame
    void Update()
    {
        calculateVelocity(rb2);
        calculateVelocity(rb3);
    }

    void calculateVelocity(Rigidbody2D inputBody) {
        float dist = Vector2.Distance(inputBody.position, transform.position);
        if (dist < 1) {dist = 1F;}
        Vector2 gforce = (Vector2) Vector3.Normalize((Vector3) inputBody.position - transform.position)*inputBody.mass*rb.mass/(dist*dist)*Time.deltaTime;
        rb.AddForce(gforce);
    }

    public float GetRandomNumber(float minimum, float maximum) {
        float rnd = (float) this.random.NextDouble();
        return ((maximum - minimum) * rnd) + minimum;
    }
}
