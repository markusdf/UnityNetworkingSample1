using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(NetworkManager))]
public class DedicatedServer : MonoBehaviour {

    private void Start()
    {

        
        if (Application.isBatchMode)
        {
            GetComponent<NetworkManager>().StartServer();   //Start dedicated server with the default port 7777
        }
        
    }
}
