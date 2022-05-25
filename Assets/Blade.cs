using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    bool isCutting = false;

    Vector2 previousPosition;

    public float minCuttingVelocity = .001f;
    Rigidbody2D rb;
    Camera cam;
    public GameObject bladetrail;
    GameObject currentbladetrail;
    CircleCollider2D circlecollider;

    private void Start()
    {
        cam = Camera.main;  //for converting mousePosition to world points
        rb= GetComponent<Rigidbody2D>();
        circlecollider = GetComponent<CircleCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            StartCutting();
        }else if(Input.GetMouseButtonUp(0))
        {

            StopCutting();
        }
        if(isCutting)
        {
            UpdateCut();
        }
    }

    void UpdateCut()
    {
        Vector2 newPosition= cam.ScreenToWorldPoint(Input.mousePosition); ;
        rb.position = newPosition;

        float velocity = (newPosition - previousPosition).magnitude / (Time.deltaTime); 
        //findin the velocity based on previousPosition and new EVERYTIME
        if(velocity > minCuttingVelocity)
        {

            circlecollider.enabled = true;
        }
        else
        {
            circlecollider.enabled = false;

        }

        previousPosition = newPosition; //it sets the previous position to the newposition, and calculate the new position again


            //magnitude is needed because we are dealing with vectors
            
            //converts to smaller points
        //so if the mouse is click it starts cutting, and move the position in the mouse direction
    }
    void StartCutting()
    {

        isCutting = true;
        //this one is a newform
        currentbladetrail = Instantiate(bladetrail, transform); //parents transform because bladetrail is under the blade
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);

        circlecollider.enabled = false; //we dont want to see it enabled on the first frame :)

        //if we start cutting in a new area we want to update our previous position
    }

    void StopCutting()
    {

        isCutting = false;
        //this removes the prefab the moment the stopcutting fucntion is called
        //THIS DEREFERENCING THE OBJECT IS FUCKING AMAZING!!!
        currentbladetrail.transform.SetParent(null);  //it removes from the parent
        Destroy(currentbladetrail, 2); //destroys after 2 seconds
        circlecollider.enabled = false;
    }
}
