using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandBullet : MonoBehaviour
{
    [SerializeField] private TrailRenderer trailRenderer;

    public bool isExpandingBullet = false;

    private float rate;
    void Update()
    {
        if (isExpandingBullet && transform.localScale.x <= 4f)
        {
            transform.localScale = new Vector3(transform.localScale.x + rate * Time.deltaTime, transform.localScale.y + rate * Time.deltaTime, transform.localScale.z);
            rate += 0.02f;
            trailRenderer.widthMultiplier = transform.localScale.x;

        }
    }
}
