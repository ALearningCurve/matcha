using UnityEngine;

public class FlipEnemySpriteOnStart : MonoBehaviour
{
    [SerializeField] private SpriteRenderer enemySpriteRenderer;

    void Start()
    {
        if (Random.value >= 0.5)
        {
            enemySpriteRenderer.flipX = true;
        }
        else
        {
            enemySpriteRenderer.flipX = false;
        }
    }

}
