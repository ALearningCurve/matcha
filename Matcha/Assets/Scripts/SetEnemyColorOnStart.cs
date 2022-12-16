using UnityEngine;

public class SetEnemyColorOnStart : MonoBehaviour
{
   
    [SerializeField] private ColorList theColors;
    [SerializeField] private SpriteRenderer enemySpriteRenderer;


    private void Start()
    {
        enemySpriteRenderer.color = theColors.colors[Random.Range(0, theColors.colors.Count)];
    }



}
