using UnityEngine;

public class LavaAnimation : MonoBehaviour
{
    public Material lavaMaterial; // Матеріал лави
    public float speedX = 0.1f;   // Швидкість руху по осі X
    public float speedY = 0f;     // Швидкість руху по осі Y

    private Vector2 offset;       // Зміщення текстури

    void Update()
    {
        // Збільшення зміщення залежно від часу
        offset.x += speedX * Time.deltaTime;
        offset.y += speedY * Time.deltaTime;

        // Застосування зміщення до матеріалу
        if (lavaMaterial != null)
        {
            lavaMaterial.mainTextureOffset = offset;
        }
    }
}
