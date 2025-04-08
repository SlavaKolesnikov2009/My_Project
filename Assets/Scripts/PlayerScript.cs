using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int speed = 10;
    private int rotate = 60;
    private float vertical;
    private float horizontal;
    public bool jump = true;
    public int power = 1000;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward*speed*Time.deltaTime*vertical);
        transform.Rotate(Vector3.up*rotate*Time.deltaTime*horizontal);
        if (jump&&Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up*power,ForceMode.Impulse);
            jump = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform")||collision.gameObject.CompareTag("PlatformCoin"))
        {
            jump = true;
        }
    }
}
