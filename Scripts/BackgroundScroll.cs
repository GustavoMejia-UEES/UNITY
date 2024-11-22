using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 0.5f; // Velocidad del fondo
    private Vector2 offset;
    private Material material;

    void Start()
    {
        // Obtén el material del sprite renderer
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Calcula el desplazamiento
        offset = new Vector2(Time.time * scrollSpeed, 0);
        material.mainTextureOffset = offset;
    }
}
