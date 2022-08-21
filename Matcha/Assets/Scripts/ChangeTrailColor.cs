using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTrailColor : MonoBehaviour
{
    void Update()
    {
        Color spriteColor = GetComponent<SpriteRenderer>().color;

        Color newStartColor = new Color(spriteColor.r, spriteColor.g, spriteColor.b, 170f);
        GetComponent<TrailRenderer>().startColor = newStartColor;

        Color newEndColor = new Color(spriteColor.r, spriteColor.g, spriteColor.b, 0f);
        GetComponent<TrailRenderer>().endColor = newEndColor;
    }
}
