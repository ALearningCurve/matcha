using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResetEnemies : MonoBehaviour
{
    /*

    [SerializeField] private GameObject enemyPrefab;

    

    public List<Transform> enemyPositions;


    private GameObject[] enemies;


    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject enemy in enemies)
        {
            enemyPositions.Add(enemy.transform);
        }



    }


    public PlayerInputActions playerControls;
    private InputAction resetEnemyPositions;


    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        resetEnemyPositions = playerControls.Player.ResetGame;
        resetEnemyPositions.Enable();
        resetEnemyPositions.performed += ResetAllEnemies;

    }

    private void OnDisable()
    {
        resetEnemyPositions.Disable();
    }


    private void ResetAllEnemies(InputAction.CallbackContext context)
    {
        
        if (context.performed)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");


            foreach(GameObject e in enemies)
            {
                Debug.Log(e);
                e.SetActive(true);
            }
/*
            if (enemies.Length == 0)
            {

                foreach (GameObject e in enemyList)
                {
                    foreach(Transform pos in enemyPositions)
                    {
                        e.transform.position = pos.position;
                    }
                    e.SetActive(true);

                }

            }
        }

    }*/

}
