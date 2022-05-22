using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject bladetrail;
    bool isCutting = false;
    Rigidbody2D rb;
    Camera cam;
    GameObject currentBladetrail; //that's why two references

    private void Start()
    {
        cam = Camera.main;  //for converting mousePosition to world points
        rb= GetComponent<Rigidbody2D>();
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

        rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
        //converts to smaller points
        //so if the mouse is click it starts cutting, and move the position in the mouse direction
    }
    void StartCutting()
    {

        isCutting = true;
        currentBladetrail=Instantiate(bladetrail, transform);   //this one is a newform
    }

    void StopCutting()
    {

        isCutting = false;
        currentBladetrail.transform.SetParent(null); //this removes the prefab the moment the stopcutting fucntion is called
        //THIS DEREFERENCING THE OBJECT IS FUCKING AMAZING!!!

    }
}
