using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int speed = 10;
    private int rotate = 120;
    private float vertical;
    private float horizontal;
    public bool jump = true;
    public int power = 1000;
    public Rigidbody rb;
    public Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        // transform.Translate(Vector3.forward*speed*Time.deltaTime*vertical);
        Vector3 MoveDeraction = new Vector3(-horizontal, 0, -vertical);
        if (MoveDeraction.magnitude>0.1f)
        {
            transform.position += MoveDeraction.normalized*speed*Time.deltaTime;
            transform.Rotate(Vector3.up*rotate*Time.deltaTime*horizontal);
            anim.SetBool("Run",true);
            // transform.forward = MoveDeraction;
        }
        else
        {
            anim.SetBool("Run",false);
        }
        if (jump&&Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up*power,ForceMode.Impulse);
            jump = false;
            anim.SetTrigger("Jump");
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
