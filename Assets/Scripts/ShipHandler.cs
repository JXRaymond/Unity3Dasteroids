using UnityEngine;
using System.Collections;

public class ShipHandler : MonoBehaviour {

    [SerializeField]forceField shield;
    public Rigidbody rb;
    Vector3 posInput;
    Vector3 rotInput;
    public AudioClip smash;

    bool powered = true;
    float speed = 150;

    public void MoveInput(Vector3 move, Vector3 rote, bool power)
    {
        posInput = move;
        rotInput = rote;
        powered = power;

        ActuallyMove();
    }

    void ActuallyMove()
    {
        if (powered)
        {
            speed = 150;
            rb.drag = 10;
        }
        else
        {
            speed = 0;
            rb.drag = 0;
        }
        rb.AddRelativeForce(posInput * speed);
        rb.AddRelativeTorque(rotInput);
    }
    void OnCollisionEnter(Collision c)
    {
        float force = 3000;

        if (c.gameObject.tag == "enemy")
        {
            // Calculate Angle Between the collision point and the player
            Vector3 dir = c.contacts[0].point - transform.position;
            // normalize Vector3
            dir = -dir.normalized;
           //addforce
            GetComponent<Rigidbody>().AddForce(dir * force);
            //livesManager.lostLife();
            AudioSource.PlayClipAtPoint(smash, transform.position);
            if (shield == null)
                return;
            shield.TakeDamange();
        }
        if(c.gameObject.tag == "alienShot")
        {
            if (shield == null)
                return;
            shield.TakeDamange();
        }
    }

}
