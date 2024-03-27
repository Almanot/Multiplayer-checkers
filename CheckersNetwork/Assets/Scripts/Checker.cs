using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public Player owner { get; private set; }
    public bool directionForward { get; private set; }
    public bool isKing { get; private set; }
    public Vector2 myPosition { get; private set; }
    int opponentEdge;

    public void SetNewPosition(Vector2 position)
    {
        myPosition = position;

        if (position.y == opponentEdge)
        {
            BecomeAKing();
        }
    }

    private void OnMouseDown()
    {
        
    }

    void BecomeAKing()
    {
        isKing = true;
    }

    void CheckMoves()
    {
        GameField.instance.CheckMovesFrom(transform.position, directionForward);
        if (isKing) { GameField.instance.CheckMovesFrom(transform.position, !directionForward); }
    }

    public void SetOwner(Player player)
    {
        if (owner == null)
        {
            owner = player;
        }
    }
}
