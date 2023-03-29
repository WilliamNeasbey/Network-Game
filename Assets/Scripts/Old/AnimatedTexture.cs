using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedTexture : MonoBehaviour
{
    public float speed = 0.5f;
    public float tiling = 1f;

    private Image image;

    void Start()
    {
        // Get the image component attached to this gameobject
        image = GetComponent<Image>();
    }

    void Update()
    {
        // Get the material from the image component
        Material material = image.material;

        // Calculate the texture offset based on time and speed
        Vector2 textureOffset = new Vector2(Time.time * speed, 0f);

        // Set the tiling and offset of the main texture
        material.mainTextureScale = new Vector2(tiling, tiling);
        material.mainTextureOffset = textureOffset;
    }
}
