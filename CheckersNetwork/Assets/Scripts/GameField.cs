using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void CheckMovesFrom(Vector2 position, bool isDirectionFront)
    {
        // if beating is able - the checker must
        List<Vector2> moves = new List<Vector2>();
        int x = (int)position.x;
        int y = (int)position.y;

        if (isDirectionFront) y++;
        else y--;
        
        if (!gameFieldSquares[x + 1, y].IsBusy) moves.Add(new Vector2(x + 1, y));
        if (!gameFieldSquares[x - 1, y].IsBusy) moves.Add(new Vector2(x - 1, y));
    }
}
