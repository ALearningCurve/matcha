using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exampleScript : MonoBehaviour
{


    public float speed;


    private float nut;

    [SerializeField]
    private float number;


    private void Awake()
    {
        
    }


    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(10f, 0f));
    }
}
