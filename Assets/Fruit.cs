using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedwatermelon;
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float force = 1.5f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //only adding one time, and not over time :)
        rb.AddForce(transform.up * force, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Blade")
        {


            //Vector3 direction = (collision.transform.position - transform.position).normalized;
            //Quaternion rotation = Quaternion.LookRotation(direction);
            //Instantiate(slicedwatermelon, transform.position, rotation);
            //Destroy(gameObject); //the one the mousei s colliding with
            Vector3 direction = (collision.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
           GameObject sliced=  Instantiate(slicedwatermelon, transform.position, rotation);
            Destroy(sliced, 3f);
            Destroy(gameObject);

        }
    }
}
