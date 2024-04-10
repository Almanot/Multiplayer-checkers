using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    const int maxPlayers = 2;
    List<Player> playerList = new List<Player>();
    int readyPlayersCount = 0;

    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public bool AddNewPlayerToGame(Player player, out GameField.Side? yourSide)
    {
        if (playerList.Count < maxPlayers && !playerList.Contains(player))
        {
            playerList.Add(player);
            // definite the player side by his position in the player list
            // TO DO : definite player position by random.
            yourSide = (GameField.Side)playerList.IndexOf(player);
            return true;
        }
        yourSide = null;
        return false;
    }

    void GameStart()
    {
        // Place figures for player on the board
        //GameField.instance.ArrangeCheckers((GameField.Side)playerList.IndexOf(player), player);
    }

    public void PlayerReady(bool prevValue, bool newValue)
    {
        if (!newValue) readyPlayersCount--;
        if (playerList.Count >= maxPlayers) { return; }
        if (newValue)
        {
            readyPlayersCount++;
            if (readyPlayersCount == maxPlayers)
            {
                GameStart();
            }
        }
    }
}
