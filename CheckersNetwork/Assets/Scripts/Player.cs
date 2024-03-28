using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string PlayerName { get; private set; }
    public bool isStrikeAvailable { get; private set; }
    public bool isPlayerSideDown { get; private set; }
    List<Checker> myCheckers = new List<Checker>();
    
    private void Start()
    {
        isStrikeAvailable = false;

        GameManager.Side side;
        if (isPlayerSideDown) side = GameManager.Side.bottom;
        else side = GameManager.Side.top;
        GameManager.instance.ArrangeCheckers(side, this);
    }

    public void ChangePlayerSide()
    {
        isPlayerSideDown = !isPlayerSideDown;
    }

    public void SetStrikeStatus(bool value)
    {
        isStrikeAvailable = value;
    }

    public void AddChecker(Checker checker)
    {
        myCheckers.Add(checker);
        checker.SetOwner(this);
    }
}
