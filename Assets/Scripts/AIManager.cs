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

        if(currentTarget != null && AIStatsManager.lookingForNeeds == true)
            MoveToTarget();

        Debug.DrawLine(transform.position, currentTarget.position, Color.red, 0.1f);

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