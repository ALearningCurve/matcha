using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    private Color matchaColor;

    void Start()
    {
        matchaColor = GetComponent<SpriteRenderer>().color;
    }

    void Update()
    {
        matchaColor = new Color(matchaColor.r, matchaColor.g, matchaColor.b, matchaColor.a - Time.deltaTime);

        GetComponent<SpriteRenderer>().color = matchaColor;

        if (matchaColor.a <= 0f)
        {
            Destroy(gameObject);
        }

    }

}
