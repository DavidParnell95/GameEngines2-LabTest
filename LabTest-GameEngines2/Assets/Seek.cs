using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBehaviour
{
    public GameObject targetObj = null;
    public Vector3 target =Vector3.zero;

    public void OnDrawGizmos()
    {
        if(isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.magenta;
            if(targetObj != null)
            {
                target = targetObj.transform.position;
            }
            Gizmos.DrawLine(transform.position, target);
        }
    }

    public override Vector3 Calculate()
    {
        return boid.SeekForce(target);
    }

    /* Update is called once per frame
    void Update()
    {
        if(targetObj != null)
        {
            target = targetObj.transform.position;
            transform.position = Vector3.MoveTowards(transform.position,target, Time.time);
        }
    }/*/

    //*
    void Update()
    {
        targetObj = FindClosestActive();
        Debug.Log(target);
        if(targetObj != null)
        {
            target = targetObj.transform.position;
            Debug.Log(target);
            transform.position = Vector3.MoveTowards(transform.position, target, Time.time);
        }
    }//*/

    public GameObject FindClosestActive()
    {
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("active");
        Debug.Log(objs);
        GameObject closest = null;

        float distance = Mathf.Infinity;
        Vector3  pos = transform.position;

        foreach (GameObject obj in objs)
        {
            Vector3 diff = obj.transform.position - pos;
            float curDistance = diff.sqrMagnitude;
            
            if(curDistance < distance)
            {
                closest = obj;
                distance = curDistance;
            }
        }

        return closest;
    }


}
