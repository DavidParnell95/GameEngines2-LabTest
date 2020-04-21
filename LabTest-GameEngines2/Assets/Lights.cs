using System;
using System.Collections;
using UnityEngine;

public class Lights : MonoBehaviour
{
    //Times for lights
    public int max =10;
    public int min =5;
    private int ylwTime = 4;
    private int interval;

    public Material material;
    Color[] colors = new Color[4];

    private int current;
    
    void Start(){
        colors[0] = Color.green;
        colors[1] = Color.yellow;
        colors[2] = Color.red;
        colors[3] = Color.yellow;

        setStartColor();
    }

    private void setStartColor()
    {
        current = UnityEngine.Random.Range(0,3);

        GetComponent<Renderer>().material.color = 
            colors[current];
    }

    // Update is called once per frame
    void Update()
    {
        if(current == 1 || current ==3)
        {
            StartCoroutine(ChangeYellow(ylwTime));
        }

        else{
            interval = UnityEngine.Random.Range(min,max);
            StartCoroutine(ChangeOther(interval));
        }
        
    }

    IEnumerator ChangeOther(int interval)
    {
        yield return new WaitForSeconds(interval);
        
        if(current == 3)
        {
            current =0;
            GetComponent<Renderer>().material.color = 
                colors[current];
            yield return new WaitForSeconds(interval);
            yield break;
        }

        else
        {
            current++;
            GetComponent<Renderer>().material.color = 
                colors[current];
            yield return new WaitForSeconds(interval);
            yield break;
        }

        
    }

    IEnumerator ChangeYellow(float ylwTime)
    {
        //Wait 4 seconds
        yield return new WaitForSeconds(ylwTime);
        if(current == 3)
        {
            current = 0;
            GetComponent<Renderer>().material.color = 
                colors[current];
            yield return new WaitForSeconds(ylwTime);
            yield break;
        }

        else
        {
            current++;
            GetComponent<Renderer>().material.color = 
                colors[current];
            yield return new WaitForSeconds(ylwTime);
            yield break;
        }
                
    }
    


    
}
