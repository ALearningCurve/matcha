using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoyBullet : MonoBehaviour
{

    public bool isBBBullet = false;

    private float rate;
    void Update()
    {
        if (isBBBullet && transform.localScale.x <= 5f)
        {
            transform.localScale = new Vector3(transform.localScale.x + rate * Time.deltaTime, transform.localScale.y + rate * Time.deltaTime, transform.localScale.z + rate * Time.deltaTime);
            rate += 0.001f;
            GetComponent<TrailRenderer>().widthMultiplier = transform.localScale.x;

        }
    }
}
