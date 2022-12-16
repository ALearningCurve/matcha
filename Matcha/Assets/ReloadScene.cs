using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public PlayerInputActions playerControls;
    private InputAction pressR;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        pressR = playerControls.Player.ResetGame;
        pressR.Enable();
        pressR.performed += ReloadTheScene;

    }

    private void OnDisable()
    {
        pressR.Disable();
    }


    private void ReloadTheScene(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}