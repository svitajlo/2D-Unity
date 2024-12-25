using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseText; // ����� ��� �����
    public AudioClip pauseSound; // ���� ��� �����
    public AudioClip resumeSound; // ���� ��� ����������

    private AudioSource audioSource;
    private bool isPaused = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pauseText.SetActive(false); // �������� ����� ����������
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // ��������� ���
        pauseText.SetActive(true); // �������� �����
        audioSource.PlayOneShot(pauseSound); // ³��������� ���� �����
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // ³��������� ���
        pauseText.SetActive(false); // ��������� �����
        audioSource.PlayOneShot(resumeSound); // ³��������� ���� ����������
    }
}
