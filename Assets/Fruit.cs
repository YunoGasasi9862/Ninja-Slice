using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedwatermelon;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Blade")
        {
            Vector3 direction = (collision.transform.position - transform.position).normalized;  //gives the magnitutde of the new position pointing from object to mous

            Quaternion rotation= Quaternion.LookRotation(direction);  //look in the direction of the face
            Instantiate(slicedwatermelon, transform.position, rotation);
            Destroy(gameObject);
          

        }
    }
}
