using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTrailColor : MonoBehaviour
{


    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private TrailRenderer trailRenderer;

    void Update()
    {
        Color spriteColor = spriteRenderer.color;

        Color newStartColor = new Color(spriteColor.r, spriteColor.g, spriteColor.b, 170f);
        trailRenderer.startColor = newStartColor;

        Color newEndColor = new Color(spriteColor.r, spriteColor.g, spriteColor.b, 0f);
        trailRenderer.endColor = newEndColor;
    }
}
