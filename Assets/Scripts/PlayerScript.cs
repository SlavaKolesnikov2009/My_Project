using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public int speed = 10;
    public int coins;
    private float vertical;
    private float horizontal;

    public bool jump = true;
    public int power = 1000;
    public bool die = true;

    public Rigidbody rb;
    public Animator anim;
    public TextMeshProUGUI textcoin;
    public GameObject win;
    public GameObject lose;
    public Camera dieCamera;
    public Camera normalCamera;

    [Range(0.1f, 9f)] [SerializeField] float sensitivity = 0.5f;
    [Range(30f, 90f)] [SerializeField] float MaxVerticalAngle = 45f;
    private float VerticalRotation = 0f;
    public Transform CameraPivot;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Cursor.lockState = CursorLockMode.Locked;
        coins = 0;
        textcoin.text = "Монеты: "+coins.ToString();
    }

    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X")*sensitivity;
        float MouseY = Input.GetAxis("Mouse Y")*sensitivity;

        transform.Rotate(0, MouseX, 0);
        VerticalRotation -= MouseY;

        VerticalRotation = Mathf.Clamp(VerticalRotation, -MaxVerticalAngle, MaxVerticalAngle);
        CameraPivot.localRotation = Quaternion.Euler(VerticalRotation, 0, 0);

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 CameraForward = Camera.main.transform.forward;
        Vector3 CameraRight = Camera.main.transform.right;

        CameraForward.y = 0;
        CameraRight.y = 0;
        CameraForward.Normalize();
        CameraRight.Normalize();

        Vector3 MoveDeraction = (CameraForward*vertical)+(CameraRight*horizontal);
        MoveDeraction.y = 0;
        MoveDeraction.Normalize();

        if (die && MoveDeraction.magnitude>0.1f)
        {
            transform.position += MoveDeraction.normalized*speed*Time.deltaTime;
            anim.SetBool("Run",true);
        }
        else
        {
            anim.SetBool("Run",false);
        }

        if (jump && die && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up*power,ForceMode.Impulse);
            jump = false;
            anim.SetTrigger("Jump");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform")||collision.gameObject.CompareTag("PlatformCoin")||collision.gameObject.CompareTag("StartPlatform"))
        {
            jump = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            dieCamera.enabled = true;
            die = false;
            lose.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            coins ++;
            textcoin.text = "Монеты: "+coins.ToString();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = collision.transform;
        }
        if (collision.gameObject.CompareTag("Win"))
        {
            win.SetActive(true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = null;
        }
    }
}
