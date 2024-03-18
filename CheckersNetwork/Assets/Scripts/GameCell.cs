using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameCell : MonoBehaviour
{
    public bool IsBusy { get; private set; }
    public Checker myChecker { get; private set; }

    GameCell()
    {
        IsBusy = false;
    }

    public void FreeTheCell()
    {
        IsBusy = false;
    }

    public bool TryOccupyTheCell(Checker checker)
    {
        if (checker == null)
        {
            IsBusy = true;
            myChecker = checker;
            return true;
        }
        else return false;
    }
}
