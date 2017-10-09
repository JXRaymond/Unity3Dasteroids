using UnityEngine;
using System.Collections;

public class alienMovement : MonoBehaviour {

    [SerializeField]Transform target;
    [SerializeField]float rotationalDamp = 20f;
    [SerializeField]float movementspeed = 50f;

    [SerializeField]float rayCastOffset = 2.5f;
    [SerializeField]float detectionDistance = 20f;

    void Update()
    {
        PathFinding();
        //Turn();
        Move();
    }

    void Turn()
    {
        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }

    void Move()
    {
        transform.position += transform.forward * movementspeed * Time.deltaTime;
    }

    void PathFinding()
    {
        RaycastHit hit;
        Vector3 raycastOffset = Vector3.zero;

        Vector3 left = transform.position - transform.right * rayCastOffset;
        Vector3 right = transform.position + transform.right * rayCastOffset;
        Vector3 up = transform.position + transform.right * rayCastOffset;
        Vector3 down = transform.position - transform.right * rayCastOffset;

        //Debug.DrawRay(left, transform.forward * detectionDistance, Color.cyan);
        //Debug.DrawRay(left, transform.forward * detectionDistance, Color.cyan);

        if(Physics.Raycast(left, transform.forward, out hit, detectionDistance))
        {
            raycastOffset += Vector3.right;
        }
        else if (Physics.Raycast(right, transform.forward, out hit, detectionDistance))
        {
            raycastOffset -= Vector3.right;
        }
        if (Physics.Raycast(up, transform.forward, out hit, detectionDistance))
        {
            raycastOffset -= Vector3.up;
        }
        else if (Physics.Raycast(down, transform.forward, out hit, detectionDistance))
        {
            raycastOffset += Vector3.up;
        }

        if (raycastOffset != Vector3.zero)
            transform.Rotate(raycastOffset * 5f * Time.deltaTime);
        else
            Turn();
    }
}
