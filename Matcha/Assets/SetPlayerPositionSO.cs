using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPositionSO : MonoBehaviour
{

    [SerializeField] private Vector3Variable playerPos;


    // Update is called once per frame
    void Update()
    {
        playerPos.Value = transform.position;
    }
}
