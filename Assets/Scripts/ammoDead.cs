using UnityEngine;
using System.Collections;

public class ammoDead : MonoBehaviour {

    // Use this for initialization
    public float timer = 3f;
    void Start () {
        Invoke("Die", timer);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void Die()
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "enemy" || other.gameObject.tag == "baby")
        {
            Destroy(other.gameObject);
        }
    }
}
