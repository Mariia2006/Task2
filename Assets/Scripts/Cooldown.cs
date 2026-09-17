using UnityEngine;
using Cysharp.Threading.Tasks;
public class Cooldown : MonoBehaviour
{
    private bool isReady = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isReady)
        {
            ActivateAbilityAsync().Forget();
        }
    }

    private async UniTaskVoid ActivateAbilityAsync()
    {
        isReady = false;
        Debug.Log("Ability used");

        await UniTask.Delay(3000, cancellationToken: this.GetCancellationTokenOnDestroy());

        Debug.Log("3 seconds passed");

        await UniTask.WaitUntil(() => !Input.GetKey(KeyCode.Space));

        isReady = true;
        Debug.Log("Ability restored");
    }
}
