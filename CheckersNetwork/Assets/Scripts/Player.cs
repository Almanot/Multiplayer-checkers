using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string PlayerName { get; private set; }
    public bool isStrikeAvailable { get; private set; }
    public bool isPlayerSideDown = true;

    private void Start()
    {
        isStrikeAvailable = false;

        GameManager.Side side;
        if (isPlayerSideDown) side = GameManager.Side.bottom;
        else side = GameManager.Side.top;
        GameManager.instance.ArrangeCheckers(side, this);
    }

    void ChangePlayerSide()
    {
        isPlayerSideDown = !isPlayerSideDown;
    }

    void StrikeAvailable()
    {
        isStrikeAvailable = true;
    }
}
