using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    List<SteeringBehaviour> behaviours = new List<SteeringBehaviour>();

    public Vector3 force = Vector3.zero;
    public Vector3 accel = Vector3.zero;
    public Vector3 vel = Vector3.zero;

    public float mass=1;

    [Range(0.0f, 10.0f)]
    public float damping = 0.01f;

    [Range(0.0f, 1.0f)]
    public float banking = 0.1f;
    public float maxSpeed = 5.0f;
    public float maxForce = 10.0f;

     // Use this for initialization
    void Start()
    {

        SteeringBehaviour[] behaviours = GetComponents<SteeringBehaviour>();

        foreach (SteeringBehaviour b in behaviours)
        {
            this.behaviours.Add(b);            
        }
    }

    public Vector3 SeekForce(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        desired.Normalize();
        desired *= maxSpeed;
        return desired - vel;
    }

    public Vector3 ArriveForce(Vector3 target, float slowingDistance = 15.0f)
    {
        Vector3 toTarget = target - transform.position;

        float distance = toTarget.magnitude;
        if (distance < 0.1f)
        {
            return Vector3.zero;
        }
        float ramped = maxSpeed * (distance / slowingDistance);

        float clamped = Mathf.Min(ramped, maxSpeed);
        Vector3 desired = clamped * (toTarget / distance);

        return desired - vel;
    }
    

    Vector3 Calculate()
    {
        force = Vector3.zero;


        foreach (SteeringBehaviour b in behaviours)
        {
            if (b.isActiveAndEnabled)
            {
                force += b.Calculate() * b.weight;

                float f = force.magnitude;
                if (f >= maxForce)
                {
                    force = Vector3.ClampMagnitude(force, maxForce);
                    break;
                }               
            }
        }

        return force;
    }


    // Update is called once per frame
    void Update()
    {
        force = Calculate();
        Vector3 newAcceleration = force / mass;
        accel = Vector3.Lerp(accel, newAcceleration, Time.deltaTime);
        vel += accel * Time.deltaTime;

        vel = Vector3.ClampMagnitude(vel, maxSpeed);
        
        if (vel.magnitude > float.Epsilon)
        {
            Vector3 tempUp = Vector3.Lerp(transform.up, Vector3.up + (accel * banking), Time.deltaTime * 3.0f);
            transform.LookAt(transform.position + vel, tempUp);

            transform.position += vel * Time.deltaTime;
            vel *= (1.0f - (damping * Time.deltaTime));
        }
    }
}