using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // for easier code reading
    public enum Side
    {
        top,
        bottom
    }

    [SerializeField]
    private GameObject checkerPrefab;
    [SerializeField]
    private GameField gameField;

    const int numberOfLines = 3; // how many lines will be busy by checkers
    const int maxPlayers = 2;
    bool[] busySide = new bool[Enum.GetNames(typeof(Side)).Length]; // To prevent place twice on the same side.
    List<Player> playerList = new List<Player>();
    
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public bool AddNewPlayer(Player player)
    {
        if (playerList.Count < maxPlayers && !playerList.Contains(player))
        {
            playerList.Add(player);
            return true;
        }
        return false;
    }
    /// <summary>
    /// Place checkers for player on the choosen side
    /// </summary>
    /// <param name="side"></param>
    /// <param name="player"></param>
    public void ArrangeCheckers(Side side, Player player)
    {
        // prevent double placing
        if (busySide[(int)side]) { return; }
        busySide[(int)side] = true;

        // if player side is top then placing calculate statring position. (- 1 for to be in the range of the gameField array)
        int y = (side == Side.bottom) ? 0 : gameField.Height - 1 - numberOfLines;
        // line on which checkers placement will end. (if placement starts from the top, then calculate the placement end line)
        int lineNumber = (side == Side.bottom) ? numberOfLines : gameField.Height; 

        for (; y < lineNumber; y++)
        {
            for (int x = 0; x < gameField.Width; x++)
            {
                // This allow to place checkers only in black cells
                if (y % 2 == 0)
                {
                    // If line number is even then place chekers only in even columns
                    if (x % 2 == 0)
                    {
                        GameObject newChecker = Instantiate(checkerPrefab, new Vector2(x, y), checkerPrefab.transform.rotation);
                        if (!gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>()))
                        {
                            Debug.LogError("Unable to place checker " + newChecker.transform.position);
                            Destroy(newChecker);
                        }
                        else newChecker.GetComponent<Checker>().SetOwner(player);
                    }
                }
                // if line number is odd then place chekers only in odd columns
                else
                {
                    if (x % 2 != 0)
                    {
                        GameObject newChecker = Instantiate(checkerPrefab, new Vector2(x, y), checkerPrefab.transform.rotation);
                        if (!gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>()))
                        {
                            Debug.LogError("Unable to place checker " + newChecker.transform.position);
                            Destroy(newChecker);
                        }
                        else newChecker.GetComponent<Checker>().SetOwner(player);
                    }
                }
            }
        }
    }
}
