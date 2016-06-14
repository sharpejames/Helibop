using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public Rigidbody rb;
    public float speed;
    public Text countText;
    public Text winText;
    private int count;
    public float altitude;
    private float startAltitude;
	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        startAltitude = rb.position.y;
        count = 0;
        updateScore();
        winText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //Code for physics updates
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool moveUp = Input.GetMouseButton(0);
        if(moveUp)
        {
            if(altitude <= 0)
            { altitude = 2; }

            altitude = altitude + 0.002f;
        }
        else
        {
            if (altitude > 2)
            {
                altitude = 0;
            }
            if (rb.position.y > 2)
            {
                altitude = altitude - 0.01f;
            } 
            else
            {
                altitude = 0;
            }
            
        }

        Vector3 movement = new Vector3(moveHorizontal, altitude, moveVertical);

        //rb.useGravity = !moveUp;
        //winText.text = altitude.ToString();

        rb.AddForce(movement * speed);

    }

    void OnTriggerEnter(Collider other)
    {
        // Destroy(other.gameObject);
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            count++;
            updateScore();
        }
    }

    void updateScore()
    {
        countText.text = "Score " + count.ToString();
        if(count >= 19)
        {
            winText.text = "You Win!";
        }
    }
}
