using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string PlayerName { get; private set; }
    public bool isStrikeAvailable { get; private set; }

    private void Start()
    {
        isStrikeAvailable = false;
    }

    public bool isPlayerSideDown {  get
        {
            return isPlayerSideDown;
        }
        private set
        {
            isPlayerSideDown = true;
        }
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
