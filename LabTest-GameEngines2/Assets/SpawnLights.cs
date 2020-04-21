/*
    Script to spawn light objects around the car
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLights : MonoBehaviour
{
    public int numberOfElements = 10;//Number of Lights to generate
    public float distance = 20;//Distance from Car to Spawn
    private int currentElements;//Amount of lights currently present

    public GameObject Car;//Object to spawn around
    public Transform Light;

    // Start is called before the first frame update
    void Start()
    {
        Car= GameObject.Find("Car");//Find car from tag
        CreateElements();
    }

    private void CreateElements()
    {
        UnityEngine.Object[] color = Resources.LoadAll("Materials", typeof(Material));

        for(int i =0; i < numberOfElements; i++)
        {
            currentElements++;
            String objName = "Light_" + currentElements;

            float angleIteration = 360/numberOfElements;
            float currentRotation = angleIteration * i;//Position around the car
            
            //Create as a transform
            Transform elem;
            elem = Instantiate(Light, Car.transform.position, 
                Car.transform.rotation) as Transform;
            
            elem.name = objName;

            elem.transform.Rotate(new Vector3(0,currentRotation,0));
            elem.transform.Translate(new Vector3(distance, 1,0));
        }
    }
}
