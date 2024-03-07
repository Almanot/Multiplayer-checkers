using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.Netcode;

public class GameMenuController : MonoBehaviour
{
    [SerializeField] Button startHost;
    [SerializeField] Button startClient;

    // Start is called before the first frame update
    void Start()
    {
        startHost.onClick.AddListener(() => { NetworkManager.Singleton.StartHost(); });
        startClient.onClick.AddListener(() => { NetworkManager.Singleton.StartClient(); });
    }
}
