using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius = 1f;
    [SerializeField] private int maxJumpCount = 2;
    [SerializeField] private float distanceToDoubleJump = 1f;
    
    private Rigidbody2D _rb;
    private bool _isGrounded;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
        // Get input from the player and move the player using rigidbody
        float horizontal = Input.GetAxis("Horizontal");
        
        _rb.velocity = new Vector2(horizontal * speed, _rb.velocity.y);
        
        if (Input.GetButton("Jump") && _isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, 0);
            _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius,groundLayer) && _rb.velocity.y <= 0;
    }
}
