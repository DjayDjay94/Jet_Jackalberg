using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour

{
    public float speed = 10.0f;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    Animator anim;

    public LayerMask groundLayers;
    public float jumpForce = 7.0f;
    public CapsuleCollider col;
    public float turnSpeed = 5.0f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";

        col = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
    }

    void Update()

    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            anim.Play(Animator.StringToHash("Move"));
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
            anim.Play(Animator.StringToHash("Move"));
        }

        {
            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }


        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        { 
            rb.AddForce(Vector3.up* jumpForce, ForceMode.Impulse);
            anim.Play(Animator.StringToHash ("Jump"));
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
            {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
                col.bounds.min.y, col.bounds.center.z), col.radius * .5f, groundLayers);
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 26)
        {
            winText.text = "Task Complete";
        }
    }
}