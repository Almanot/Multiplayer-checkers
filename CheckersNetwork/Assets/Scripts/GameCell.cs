using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameCell : MonoBehaviour
{
    public bool IsBusy { get; private set; }
    private Checker myChecker { get; set; }

    GameCell()
    {
        IsBusy = false;
    }

    public void FreeTheCell()
    {
        IsBusy = false;
    }

    public void OccupyTheCell(Checker checker)
    {
        if (checker == null)
        {
            IsBusy = true;
            myChecker = checker;
        }
    }
}
