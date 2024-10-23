using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float jumpForce = 25.0f;
    
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;
    private bool _isGrounded;
    private bool _jumpPressed;
    
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        _animator.SetFloat(Horizontal, horizontal);
        _animator.SetBool(IsWalking, horizontal != 0);
        _spriteRenderer.flipX = horizontal > 0 && Mathf.Abs(horizontal) > 0.1f;
        if (Input.GetKeyDown(KeyCode.Space)) _jumpPressed = true;
    }
    
    private void FixedUpdate()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var velocity = new Vector2(x * speed, _rb.velocity.y);
        _rb.velocity = velocity;
        
        CheckGrounded();

        if (!_jumpPressed || !_isGrounded) return;
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        _isGrounded = false;
        _jumpPressed = false;
    }
    
    private void CheckGrounded()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f);
        _isGrounded = hit.collider != null && hit.collider.CompareTag("Ground");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform")) 
            transform.SetParent(other.transform);
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
            transform.SetParent(null);
    }
}
