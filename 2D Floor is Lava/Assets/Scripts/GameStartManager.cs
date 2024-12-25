using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    public GameObject startText; // �����, ���� ������� �������
    private bool gameStarted = false;

    void Start()
    {
        // ������������, �� ��� �������� �� �������
        Time.timeScale = 0;

        // ������������, �� ����� ��������
        if (startText != null)
        {
            startText.SetActive(true);
        }
    }

    void Update()
    {
        // ���� ��������� ����-��� ������ � ��� �� �� ��������
        if (!gameStarted && Input.anyKeyDown)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        gameStarted = true;

        // ������ �����
        if (startText != null)
        {
            startText.SetActive(false);
        }

        // ��������� ���
        Time.timeScale = 1;
    }
}
