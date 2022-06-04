using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedwatermelon;
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float force = 15f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * force, ForceMode2D.Impulse); //only adding one time, and not over time :)
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Blade")
        {
          

            Vector3 direction = (collision.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            Instantiate(slicedwatermelon, transform.position, rotation);
            Destroy(gameObject); //the one the mousei s colliding with
          

        }
    }
}
