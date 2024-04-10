using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameCell
{
    public bool IsBusy { get; private set; }
    public Checker myChecker { get; private set; }

    // To Do make this private
    public void FreeTheCell()
    {
        GameObject.Destroy(myChecker.gameObject);
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
