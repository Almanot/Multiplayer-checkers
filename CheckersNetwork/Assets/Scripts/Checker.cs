using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public Player owner {  get; private set; }
    public bool directionForward { get; private set; }
    public bool isKing { get; private set; }
    public Vector2 myPosition { get; private set; }
    int opponentEdge;

    public void SetNewPosition(Vector2 position)
    {
        myPosition = position;

        if (position.y == opponentEdge)
        {
            BecomeKing();
        }
    }

    private void OnMouseDown()
    {
        
    }

    void BecomeKing()
    {
        isKing = true;
    }

    void CheckMoves()
    {
        GameField.instance.CheckMovesFrom(transform.position, directionForward);
        if (isKing) { GameField.instance.CheckMovesFrom(transform.position, !directionForward); }
    }
}
