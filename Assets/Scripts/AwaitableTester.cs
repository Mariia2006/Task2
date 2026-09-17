using UnityEngine;

public class AwaitableTester : MonoBehaviour
{
    async void Start()
    {
        Debug.Log("Start! Waiting 3 seconds...");
        await Awaitable.WaitForSecondsAsync(3f);

        Debug.Log("3 seconds passed");

        GetComponent<Renderer>().material.color = Color.red;
        await Awaitable.WaitForSecondsAsync(3f);
        await MoveCubeUpAsync();

        Debug.Log("Movement completed!");
        GetComponent<Renderer>().material.color = Color.green;
    }

    async Awaitable MoveCubeUpAsync()
    {
        Debug.Log("Start moving upwards");
        for (int i = 0; i < 60; i++)
        {
            transform.Translate(Vector3.up * 0.05f);
            await Awaitable.NextFrameAsync();
        }
    }
}
