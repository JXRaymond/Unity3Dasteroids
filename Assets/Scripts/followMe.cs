using UnityEngine;
using System.Collections;

public class followMe : MonoBehaviour {

    Transform tr_player;
    Rigidbody rb;
    float rotSpeed = 3.0f, moveSpeed = 3.0f;
    public float tumble;
    public float maxdistance;
    public GameObject explosion;
    public GameObject asteroidBaby;
    public AudioClip bang;
    bool yes = true;
    bool No = true;

    public int pointsToAdd;

    // Use this for initialization
    void Start () {
        tr_player = GameObject.FindGameObjectWithTag("Player").transform;

        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
	
	// Update is called once per frame
	void Update () {
        // transform.rotation = Quaternion.Slerp(transform.rotation
        //, Quaternion.LookRotation(tr_player.position - transform.position)
        // , rotSpeed * Time.deltaTime);

        //transform.position += transform.forward * moveSpeed * Time.deltaTime;

        //rb.angularVelocity = Random.insideUnitSphere * tumble;
        if (Vector3.Distance(tr_player.position, transform.position) > maxdistance)
        {
            // Get a direction vector from us to the target
            Vector3 dir = tr_player.position - transform.position;

            // Normalize it so that it's a unit direction vector
            dir.Normalize();

            // Move ourselves in that direction
            transform.position += dir * moveSpeed * Time.deltaTime;
        }


    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "projectile" && yes == true)
        {
            yes = false;
            asteroidSpawn.counter();
            scoreManager.AddPoints(pointsToAdd);
            Instantiate(asteroidBaby, transform.position, transform.rotation);
            Instantiate(asteroidBaby, transform.position, transform.rotation);
            Instantiate(explosion, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(bang, transform.position);
       
            //No = false;
            Destroy(other.gameObject);
           // Destroy(this);
        }
    }
}
