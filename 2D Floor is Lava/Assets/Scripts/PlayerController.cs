using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� ����
    public float jumpForce = 10f; // ���� �������

    public AudioClip runSound; // ���� ���
    public AudioClip jumpSound; // ���� �������
    public AudioClip attackSound; // ���� �����
    public AudioClip hurtSound; // ���� ��������� �����

    private Rigidbody2D rb;
    private Animator animator;
    private AudioSource audioSource; // ��������� ��� ���������� �����
    private bool isGrounded;

    private bool isPlayingRunSound = false; // �� ��� ���� ��� �����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // �������� Rigidbody2D
        animator = GetComponent<Animator>(); // �������� Animator
        audioSource = GetComponent<AudioSource>(); // �������� AudioSource
    }

    void Update()
    {
        // ��� ����/������
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // ������� ����
        animator.SetBool("isRun", moveInput != 0);

        // ³��������� ����� ���
        if (isGrounded && moveInput != 0)
        {
            if (!isPlayingRunSound)
            {
                audioSource.clip = runSound;
                audioSource.loop = true; // ������� ����������� �����
                audioSource.Play();
                isPlayingRunSound = true;
            }

            // ������� �������� ����� ������� �� �������� ����
            audioSource.pitch = Mathf.Abs(moveInput); // ��� ������ �������� ��������, ��� ������ ����
        }
        else
        {
            if (isPlayingRunSound)
            {
                audioSource.loop = false; // ��������� ����
                isPlayingRunSound = false;
            }
        }

        // ������� �����
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // �������
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // �����
        }

        // �������
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isJump", true);
            audioSource.PlayOneShot(jumpSound); // ³��������� ����� �������
        }

        // �����
        if (Input.GetKeyDown(KeyCode.J)) // �������� "J" ��� �����
        {
            animator.SetTrigger("attack");
            audioSource.PlayOneShot(attackSound); // ³��������� ����� �����
        }

        // ��������� �����
        if (Input.GetKeyDown(KeyCode.H)) // �������� "H" ��� �����
        {
            animator.SetTrigger("hurt");
            audioSource.PlayOneShot(hurtSound); // ³��������� ����� ��������� �����
        }

        // �������� �����
        if (Input.GetKey(KeyCode.W)) // �������� "W" ��� LookUp
        {
            animator.SetBool("isLookUp", true);
        }
        else
        {
            animator.SetBool("isLookUp", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ��������, �� ����� ��������� ����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // ���� ����� ����� �� ��������� ����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
