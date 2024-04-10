using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public Player myOwner { get; private set; }
    public bool isKing { get; private set; }
    public Vector2 myPosition { get; private set; }
    List<Move> availableMoves;

    private void Start()
    {
        //GameManager.gameBeginCallback += CheckMoves();
    }
    void OnGameBegin()
    {
        CheckMoves();
    }
    public void MoveToCell(Vector2 position)
    {
        myPosition = position;

    }

    private void OnMouseDown()
    {
        
    }

    void BecomeAKing()
    {
        isKing = true;
    }

    /// <summary>
    /// Check available moves for current checker
    /// </summary>
    void CheckMoves()
    {
        availableMoves = GameField.instance.CheckMovesFrom(transform.position, myOwner.isMovingForward);
        if (isKing) { GameField.instance.CheckMovesFrom(transform.position, !myOwner.isMovingForward); }
    }

    public void SetOwner(Player player)
    {
        if (myOwner == null)
        {
            myOwner = player;
            player.AddChecker(this);
        }
    }

    void DoAMove(Move move)
    {

    }
}
