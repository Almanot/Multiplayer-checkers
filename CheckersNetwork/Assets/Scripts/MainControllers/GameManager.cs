using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    // for easier code reading
    public enum Side
    {
        bottom,
        top
    }

    
    [SerializeField] private GameField gameField;
    [SerializeField] private NetworkManager networkManager;

    const int maxPlayers = 2;
    List<Player> playerList = new List<Player>();

    public delegate void PlayerConnectionCallback(Player player);
    public static Action<PlayerConnectionCallback> connectionCallback;
    
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public bool AddNewPlayerToGame(Player player, out Side? yourSide)
    {
        if (playerList.Count < maxPlayers && !playerList.Contains(player))
        {
            playerList.Add(player);
            // definite the player side by his position in the player list
            // TO DO : definite player position by random.
            yourSide = (Side)playerList.IndexOf(player);
            // Place figures for player on the board
            gameField.ArrangeCheckers((Side)playerList.IndexOf(player), player);
            // Position player data on UI

            if (playerList.Count == maxPlayers)
            {
                GameStart();
            }
            return true;
        }
        yourSide = null;
        return false;
    }

    void GameStart()
    {

    }

    void PassingAMove()
    {

    }

    

}
