using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Швидкість руху
    public float jumpForce = 10f; // Сила стрибка

    public AudioClip runSound; // Звук бігу
    public AudioClip jumpSound; // Звук стрибка
    public AudioClip attackSound; // Звук атаки
    public AudioClip hurtSound; // Звук отримання шкоди

    private Rigidbody2D rb;
    private Animator animator;
    private AudioSource audioSource; // Компонент для відтворення звуків
    private bool isGrounded;

    private bool isPlayingRunSound = false; // Чи грає звук бігу зараз

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Отримуємо Rigidbody2D
        animator = GetComponent<Animator>(); // Отримуємо Animator
        audioSource = GetComponent<AudioSource>(); // Отримуємо AudioSource
    }

    void Update()
    {
        // Рух вліво/вправо
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Анімація руху
        animator.SetBool("isRun", moveInput != 0);

        // Відтворення звуку бігу
        if (isGrounded && moveInput != 0)
        {
            if (!isPlayingRunSound)
            {
                audioSource.clip = runSound;
                audioSource.loop = true; // Циклічне програвання звуку
                audioSource.Play();
                isPlayingRunSound = true;
            }

            // Змінюємо швидкість звуку залежно від швидкості руху
            audioSource.pitch = Mathf.Abs(moveInput); // Чим швидше рухається персонаж, тим швидше звук
        }
        else
        {
            if (isPlayingRunSound)
            {
                audioSource.loop = false; // Зупиняємо цикл
                isPlayingRunSound = false;
            }
        }

        // Поворот героя
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Направо
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Наліво
        }

        // Стрибок
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isJump", true);
            audioSource.PlayOneShot(jumpSound); // Відтворення звуку стрибка
        }

        // Атака
        if (Input.GetKeyDown(KeyCode.J)) // Нажимаємо "J" для атаки
        {
            animator.SetTrigger("attack");
            audioSource.PlayOneShot(attackSound); // Відтворення звуку атаки
        }

        // Отримання шкоди
        if (Input.GetKeyDown(KeyCode.H)) // Нажимаємо "H" для шкоди
        {
            animator.SetTrigger("hurt");
            audioSource.PlayOneShot(hurtSound); // Відтворення звуку отримання шкоди
        }

        // Дивитись вгору
        if (Input.GetKey(KeyCode.W)) // Нажимаємо "W" для LookUp
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
        // Перевірка, чи герой торкається землі
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Якщо герой більше не торкається землі
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
