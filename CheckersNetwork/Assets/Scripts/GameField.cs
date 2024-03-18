using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameField : MonoBehaviour
{
    GameCell [,] gameFieldSquares;
    public static GameField instance;
    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }

    private void Start()
    {
        gameFieldSquares = new GameCell[8, 8]; // first array dimension is letter and second is number lines on the board
    }

    public void CheckMovesFrom(Vector2 position, bool isFrontDirection)
    {
        // if beating is able - the checker must
        List<Move> availableMoves = new List<Move>();
        List<Vector2> availableStrikes = new List<Vector2>();
        int x = (int)position.x;
        int y = (int)position.y;

        if (isFrontDirection) y++;
        else y--;

        // Check 2 diagonal cells in choosen direction (forward or backward)
        
        if (gameFieldSquares.GetLength(0) <= x + 1) // Check if target cell exist
        {
            if (gameFieldSquares[x + 1, y].IsBusy) // Identify the checker owner if cell is busy
            {
                Checker meetedChecker = gameFieldSquares[x + 1, y].myChecker;
                Checker choosedChecker = gameFieldSquares[x, (int)position.y].myChecker;

                if (meetedChecker.owner != choosedChecker.owner)
                {
                    // check the cell behind opponent checker
                    if (!gameFieldSquares[x + 2, y + 1].IsBusy) {
                        // Add to available strikes and continue to check the space around new place
                    }
                }
            }
            else
            {
                availableMoves.Add(new Move(false, new Vector2(x + 1, y)));
            }
        }
            
        if (x - 1 > 0 &&
            !gameFieldSquares[x - 1, y].IsBusy)
        {
            availableMoves.Add(new Move(false, new Vector2(x + 1, y)));
        }
    }
}
