using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using Newtonsoft.Json;
using Cysharp.Threading.Tasks;

[System.Serializable]
public class UserData
{
    public int id;
    public string name;
    public string role;
}
public class NetworkTester : MonoBehaviour
{
    private const string GET_URL = "https://jsonplaceholder.typicode.com/users/1";
    private const string POST_URL = "https://jsonplaceholder.typicode.com/posts";
    async void Start()
    {
        Debug.Log("Starting network test");
        await GetUserDataAsync();
        await PostUserDataAsync();
    }

    void Update()
    {
        
    }

    private async UniTask GetUserDataAsync()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(GET_URL))
        {
            await request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                string jsonResponse = request.downloadHandler.text;
                Debug.Log($"Get JSON: {jsonResponse}");

                UserData user = JsonConvert.DeserializeObject<UserData>(jsonResponse);
                Debug.Log($"Parsed: {user.name}");
            }
            else
            {
                Debug.Log(request.error);
            }
        }
    }

    private async UniTask PostUserDataAsync()
    {
        UserData newUser = new UserData { id = 87, name = "Alex", role = "Admin"};
        string jsonToSend = JsonConvert.SerializeObject(newUser);

        using (UnityWebRequest request = new UnityWebRequest(POST_URL, "POST"))
        {
            // json -> array of bytes
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonToSend);

            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();

            request.SetRequestHeader("Content-Type", "application/json");
            await request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log($"Server`s answer: \n{request.downloadHandler.text}");
            }
            else
            {
                Debug.Log(request.error);
            }
        }
    }
}
