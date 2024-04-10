using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static GameManager;

public class GameField : MonoBehaviour
{
    // for game field array dimensions
    enum Dimensions
    {
        horizontal,
        vertical
    }

    public int Width { get { return 8; } }
    public int Height { get { return 8; } }

    [SerializeField] GameObject FigurePrefab;
    const int numberOfLines = 3; // how many lines will be busy by checkers
    GameCell [,] gameFieldSquares;
    List<Checker> checkerList;
    public static GameField instance;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }

    private void Start()
    {
        gameFieldSquares = new GameCell[Width, Height]; // first array dimension is letter and second is number lines on the board
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                gameFieldSquares[x, y] = new GameCell();
            }
        }
        checkerList = new List<Checker>();
    }

    /// <summary>
    /// Checkers should get availabe moves from this method.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="isPositiveDirection"></param>
    /// <returns></returns>
    public List<Move> CheckMovesFrom(Vector2 position, bool isPositiveDirection)
    {
        // values for requests to array
        int originX = (int)position.x;
        int originY = (int)position.y;

        // starter coordinates validity check (example x or y = -1)
        if (!InRange(originX, Dimensions.horizontal) || !InRange(originY, Dimensions.vertical)) { return null; }

        // NOTE: if beating is able - the checker must
        // returnable list
        List<Move> actions = new List<Move>();

        // scan direction determination
        // positive or negative is meant direction of increased or decreased numbers on game board 
        int y = isPositiveDirection ? originY + 1: originY - 1;
        int x = originX + 1;

        // exit of method if end of gameboard reached
        if (!InRange(y, Dimensions.vertical)) { return null; } 

        // Checks 2 diagonal cells from current, in choosen direction
        #region CheckCycle
        // Check one cell in positive direction (positive direction is right)
        if (InRange(x, Dimensions.horizontal))
        {
            if (gameFieldSquares[x, y].IsBusy) // Identify the checker owner if cell is busy
            {
                Checker meetedChecker = gameFieldSquares[x, y].myChecker;
                Checker currentChecker = gameFieldSquares[originX, originY].myChecker;

                if (meetedChecker.myOwner != currentChecker.myOwner) // check is it opponent checker or no
                {
                    // if it is an opponent checker then define if strike is available
                    // check the cell behind opponent checker
                    y = isPositiveDirection ? y + 1 : y - 1;
                    x++;
                    if (InRange(y, Dimensions.vertical) && 
                        InRange(x, Dimensions.horizontal))
                    {
                        if (!gameFieldSquares[x, y].IsBusy)
                        {
                            // Add to available strikes
                            actions.Add(new Move(true, new Vector2(x, y)));
                            // keep checking the area around the new location
                            List<Move> moves = CheckMovesFrom(new Vector2(x, y), isPositiveDirection);
                            // Merge current first Move from list of actions with first Move from returned list of actions
                            actions[0].path.AddRange(moves[0].path);
                            // Remove the move which were merged before.
                            moves.RemoveAt(0);
                            // Add remaining moves to list
                            actions.AddRange(moves);
                        }
                    }
                    // if cell out of game field range, then move unavailable
                }
                // if checker is owned then it's a dead end, move unavailable
            }
            else // if checked cell is free and available for occupation
            {
                actions.Add(new Move(false, new Vector2(x, y)));
            }
        }

        // Check one cell in negative direction
        x = originX - 1;
        if (InRange(x, Dimensions.horizontal))
        {
            if (gameFieldSquares[x, y].IsBusy) // Identify the checker owner if cell is busy
            {
                Checker meetedChecker = gameFieldSquares[x, y].myChecker;
                Checker currentChecker = gameFieldSquares[originX, originY].myChecker;

                if (meetedChecker.myOwner != currentChecker.myOwner) // check is it opponent checker or no
                {
                    // if it is an opponent checker then define if strike is available
                    // check the cell behind opponent checker
                    y = isPositiveDirection ? y + 1 : y - 1;
                    x--;
                    if (InRange(y, Dimensions.vertical) &&
                        InRange(x, Dimensions.horizontal))
                    {
                        if (!gameFieldSquares[x, y].IsBusy)
                        {
                            // Add to available strikes
                            actions.Add(new Move(true, new Vector2(x, y)));
                            // keep checking the area around the new location
                            List<Move> moves = CheckMovesFrom(new Vector2(x, y), isPositiveDirection);
                            // Merge current first Move from list of actions with first Move from returned list of actions
                            actions[0].path.AddRange(moves[0].path);
                            // Remove the move which were merged before.
                            moves.RemoveAt(0);
                            // Add remaining moves to list
                            actions.AddRange(moves);
                        }
                    }
                    // if cell out of game field range, then move unavailable
                }
                // if checker is owned then it's a dead end, move unavailable
            }
            else // if checked cell is free and available for occupation
            {
                actions.Add(new Move(false, new Vector2(x, y)));
            }
        }
        return actions;

        #endregion
    }

    /// <summary>
    /// Check if value is in range of game field
    /// </summary>
    /// <param name="value"></param>
    /// <param name="dimension"></param>
    /// <returns></returns>
    bool InRange (int value, Dimensions dimension)
    {
        if (value < gameFieldSquares.GetLength((int)dimension) && value > 0) return true;
        else return false;
    }

    /// <summary>
    /// Add checker on the game field in coordinates
    /// </summary>
    /// <param name="coords"></param>
    /// <param name="newChecker"></param>
    /// <returns></returns>
    public bool AddFigure(Vector2 coords, Checker newChecker)
    {
        bool result = gameFieldSquares[(int)coords.x, (int)coords.y].ClaimTheCell(newChecker);
        if (!result) return false;
        checkerList.Add(newChecker);
        return true;
    }

    /// <summary>
    /// Place checkers for player on the choosen side
    /// </summary>
    /// <param name="side"></param>
    /// <param name="player"></param>
    public void ArrangeCheckers(Side side, Player player)
    {

        // if player side is top then placing calculate statring position.
        int y = (side == Side.bottom) ? 0 : Height - numberOfLines;
        // line on which checkers placement will end. (if placement starts from the top, then calculate the placement end line)
        int lineNumber = (side == Side.bottom) ? numberOfLines : Height;

        for (; y < lineNumber; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                // This allow to place checkers only in black cells
                if (y % 2 == 0)
                {
                    // If line number is even then place chekers only in even columns
                    if (x % 2 == 0)
                    {
                        GameObject newChecker = Instantiate(FigurePrefab, new Vector2(x, y), FigurePrefab.transform.rotation);
                        if (!AddFigure(newChecker.transform.position, newChecker.GetComponent<Checker>()))
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
                        GameObject newChecker = Instantiate(FigurePrefab, new Vector2(x, y), FigurePrefab.transform.rotation);
                        if (!AddFigure(newChecker.transform.position, newChecker.GetComponent<Checker>()))
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
