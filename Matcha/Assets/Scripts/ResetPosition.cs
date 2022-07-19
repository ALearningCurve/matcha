using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    private Vector2 originalPos = Vector2.zero;
    void Start()
    {
        originalPos = gameObject.transform.position;

    }
    void Update()
    {
        if(gameObject.transform.position.y < -20f)
        {
            gameObject.transform.position = originalPos;
            Debug.Log("Fell out of bounds, position reset");
        }
    }
}
