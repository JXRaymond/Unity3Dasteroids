using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour {

    ShipHandler sHand;

    public AudioSource flying;

    GameObject pitch1;
    GameObject yaw1;
    GameObject roll1;
    GameObject x1;
    GameObject y1;
    GameObject z1;
    GameObject ship;
    Text text;
    Text text2;
    Text text3;
    Text text4;
    Text text5;
    Text text6;
    Transform T;

    Vector3 moveInput;
    Vector3 rotInput;

    bool powered = true;

	// Use this for initialization
	void Start () {
        sHand = GetComponent<ShipHandler>();
        text = pitch1.GetComponent<Text>();
        text2 = yaw1.GetComponent<Text>();
        text3 = roll1.GetComponent<Text>();
        text4 = x1.GetComponent<Text>();
        text5 = y1.GetComponent<Text>();
        text6 = z1.GetComponent<Text>();
        flying = GetComponent<AudioSource>();
        T = ship.transform;

	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float u = Input.GetAxisRaw("Vert2");

        float rh = Input.GetAxisRaw("Mouse X"); //yaw
        float rv = Input.GetAxisRaw("Mouse Y"); //pitch
        float ru = Input.GetAxisRaw("MouseY2");

        moveInput = new Vector3(h, u, v);
        rotInput = new Vector3(rv, rh, ru);

        text.text = "Pitch: " + T.transform.localEulerAngles.y.ToString();
        text2.text = "Yaw: " + T.transform.localEulerAngles.x.ToString();
        text3.text = "Roll: " + T.transform.localEulerAngles.z.ToString();
        text4.text = "x: " + T.transform.position.x.ToString();
        text5.text = "y: " + T.transform.position.y.ToString();
        text6.text = "z: " + T.transform.position.z.ToString();

        //if(Input.GetKeyDown(KeyCode.P))
        //{
        //    powered = !powered;
        //}

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            flying.Play();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            flying.Stop();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            flying.Play();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            flying.Stop();
        }
    }

    void FixedUpdate()
    {
        sHand.MoveInput(moveInput, rotInput, powered);
    }

    void Awake()
    {
        pitch1 = GameObject.Find("pitchTitle");
        yaw1 = GameObject.Find("yawTitle");
        roll1 = GameObject.Find("rollTitle");
        x1 = GameObject.Find("xTitle");
        y1 = GameObject.Find("yTitle");
        z1 = GameObject.Find("zTitle");
        ship = GameObject.Find("SHIP");
    }
}
