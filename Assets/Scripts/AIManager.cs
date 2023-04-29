using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    
    [Header("target manager")]
    public Transform currentTarget;
    public List<Transform> targets;
    public Rigidbody rb;

    [Header("movement manager")]
    public float velocity;
    public Vector3 saveSpace;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {

        if(currentTarget != null)
            MoveToTarget();

        float rayLength = GetComponent<SphereCollider>().radius / 2;
        Debug.DrawRay(transform.position, -transform.forward * rayLength, Color.red); 

        transform.LookAt(new Vector3(0, currentTarget.position.y, 0));
    }

    void OnTriggerEnter(Collider other) 
    {

        if((other.gameObject.layer == LayerMask.NameToLayer("Flower")))
            targets.Add(other.transform);
        
        GetNearest();
    }

    void OnTriggerExit(Collider other) 
    {

        if((other.gameObject.layer == LayerMask.NameToLayer("Flower")))
            targets.Remove(other.transform);

        GetNearest();
    }

    private void OnTriggerStay(Collider other) 
    {

        GetNearest();
    }

    public void GetNearest()
    {

        Transform nearestTarget = null;

        if(targets.Count <= 0) return;
        
        foreach (var target in targets)
        {

            if(!nearestTarget) nearestTarget = target;

            if(Vector3.Distance(transform.position, nearestTarget.position) > Vector3.Distance(transform.position, target.position))
                nearestTarget = target;
        }

        currentTarget = nearestTarget;
    }

    void MoveToTarget()
    {
        
        Vector3 direction = (currentTarget.position - saveSpace) - transform.position;
        //transform.Translate(direction * 1f * Time.deltaTime);
        rb.MovePosition(transform.position + direction * velocity * Time.deltaTime);
    }
}