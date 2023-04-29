using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    
    public Transform currentTarget;
    public List<Transform> targets;
    public Rigidbody rb;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if(currentTarget != null)
            MoveToTarget();
        
        Debug.DrawRay(transform.position, transform.forward, Color.red);
    }

    void OnTriggerEnter(Collider other) 
    {

        if(!targets.Contains(other.transform))
            targets.Add(other.transform);
        
        GetNearest();

    }

    void OnTriggerExit(Collider other) 
    {

        if(targets.Contains(other.transform))
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

        // rb.MovePosition(Vector3.MoveTowards(transform.position, currentTarget.position, Time.fixedDeltaTime * 50f));
        Vector3 direction = currentTarget.position - transform.position;
        transform.Translate(direction * 1f * Time.deltaTime);
    }
}
