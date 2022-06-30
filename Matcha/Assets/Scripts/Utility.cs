using System;
using System.Collections;
using UnityEngine;
using Mirror;

public static class Utility
{
    /// <summary>
    /// Extension method to allow running the Invoke command for lambdas
    /// </summary>
    /// <param name="mb"></param>
    /// <param name="f">the lambda</param>
    /// <param name="delay">delay in seconds</param>
    public static void Invoke(this NetworkBehaviour mb, Action f, float delay)
    {
        mb.StartCoroutine(InvokeRoutine(f, delay));
    }

    private static IEnumerator InvokeRoutine(Action f, float delay)
    {
        Debug.Log("about to wait: " + delay) ;
        yield return new WaitForSeconds(delay);
        Debug.Log("done waiting");
        f();
        Debug.Log("done running function");
        yield return null;
    }
}