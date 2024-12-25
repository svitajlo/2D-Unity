using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Герой, за яким слідкує камера
    public Vector3 offset = new Vector3(0, 1, -10); // Зсув камери відносно героя
    public float smoothSpeed = 0.125f; // Швидкість згладжування руху

    void LateUpdate()
    {
        if (target != null)
        {
            // Бажана позиція камери
            Vector3 desiredPosition = target.position + offset;

            // Згладжування руху камери
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Оновлення позиції камери
            transform.position = smoothedPosition;
        }
    }
}
