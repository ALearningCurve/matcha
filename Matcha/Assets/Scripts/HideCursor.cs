using UnityEngine;

public class HideCursor : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        if(Cursor.visible == true)
        {
            Cursor.visible = false;
        }
    }
    
}
