using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Button startHost;
    [SerializeField] Button startClient;
    [SerializeField] Button ready;
    [SerializeField] GameObject StarterMenu;
    [SerializeField] GameObject playerDataBox;
    [SerializeField] GameObject playerDataHolderPrefab;

    // Start is called before the first frame update
    void Start()
    {
        startHost.onClick.AddListener(() => { NetworkManager.Singleton.StartHost(); });
        // Need to close the menu panel only after successful connection to the game.
        // For know when the connection successful need to get feedback from connection method.
        // For that one need to link to NetworkManager event.
        startClient.onClick.AddListener(() => { NetworkManager.Singleton.StartClient(); });
    }

    public void ApplicationQuit()
    {
        Debug.Log("app quit");
        Application.Quit();
    }

    public void AbortTheGame()
    {
        NetworkManager.Singleton.Shutdown();
    }

    public void CloseStarterMenu()
    {
        StarterMenu.gameObject.SetActive(false);
    }
}
