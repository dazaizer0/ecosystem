// by marcel
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 0.3f, sprintMult = 2.5f;
    private float translateSpeed;
    Rigidbody rb;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        translateSpeed = speed / 200;
    }
    void Update()
    {
        Vector3 axis = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal")) * speed;
        rb.velocity = axis;

        transform.Translate((Input.GetMouseButton(3) ? sprintMult * translateSpeed : translateSpeed) *
            (Input.GetKey(KeyCode.Space) ? Vector3.up : (Input.GetKey(KeyCode.LeftShift)) ? Vector3.down : Vector3.zero));
    }
}
