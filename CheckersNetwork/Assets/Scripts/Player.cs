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
    GameField.Side? starterPosition;
    public bool isMovingForward
    { 
        get
        {
            // TO DO : change logic for move direction definition. Need separate class for rules
            if (starterPosition == GameField.Side.bottom) return true;
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
        UIController interfaceController = FindFirstObjectByType<UIController>();
        if (interfaceController != null) 
        {
            // If plyer spawned and start executed, interface can be closed
            interfaceController.CloseStarterMenu(); 
            // subscribe to just spawned player entitie to ready button.
            interfaceController.ReadyButton.onClick.AddListener(GetReady);
            // subscribe isReady variable to GameManager. When all players will be ready, GameMager will start the game.
            isReady.OnValueChanged += GameManager.instance.PlayerReady;
        }
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
