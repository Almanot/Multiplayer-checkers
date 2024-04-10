using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{
    // Should be set to false before begin new game.
    private NetworkVariable<bool> isReady = new NetworkVariable<bool>(false);
    public string PlayerName { get; private set; }
    public bool isStrikeAvailable { get; private set; }
    List<Checker> myFigures = new List<Checker>();
    GameManager.Side? starterPosition;
    public bool isMovingForward 
    { 
        get
        {
            // TO DO : change logic for move direction definition. Need separate class for rules
            if (starterPosition == GameManager.Side.bottom) return true;
            else return false;
        }
    }
    
    private void Start()
    {
        SetStrikeStatus(false);
        // Try to add player to game. If it false, disconnect him from the game.
        if (!GameManager.instance.AddNewPlayerToGame(this, out starterPosition))
        {
            NetworkManager.Singleton.Shutdown();
            Destroy(gameObject);
            return;
        }
        // This need to close the starter UI menu only after successful connect to host
        FindFirstObjectByType<GameMenuController>().CloseStarterMenu();
    }

    public void SetStrikeStatus(bool value)
    {
        isStrikeAvailable = value;
    }

    public void AddChecker(Checker checker)
    {
        myFigures.Add(checker);
        checker.SetOwner(this);
    }

    public void RemoveChecker(Checker checker)
    {
        myFigures.Remove(checker);
    }

    
    public void GetReady()
    {
        isReady.Value = true;
    }
}
