using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameCell
{
    public bool IsBusy { get; private set; }
    public Checker myChecker { get; private set; }

    public void FreeTheCell()
    {
        myChecker = null;
        IsBusy = false;
    }

    public bool ClaimTheCell(Checker checker)
    {
        if (myChecker == null)
        {
            IsBusy = true;
            myChecker = checker;
            return true;
        }
        else return false;
    }
}
