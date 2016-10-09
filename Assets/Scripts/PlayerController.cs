using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private int count;
    public float velocity;
    public Text countText;
    public Text winText;
    public GameObject pickups;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool jump = Input.GetButtonDown("Jump");
        if (jump)
        {
            rb.AddForce(new Vector3(0f, 300f, 0f));
        }
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rb.AddForce(movement * velocity);
    }

    void OnTriggerEnter(Collider other)
    {
        string pickups = other.transform.parent.gameObject.name;
        Debug.Log(pickups);
        if (pickups == "Pickups")
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= pickups.transform.childCount)
        {
            winText.text = "You Win!";
        }
    }
}
