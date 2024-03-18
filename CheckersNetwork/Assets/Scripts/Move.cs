using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : ScriptableObject
{
    public bool isStrike { get; private set; }
    public List<Vector2> path = new List<Vector2>();
    public Color color { get; private set; }

    public Move(bool isStrike, Vector2 freeCellCoordinates) : this(isStrike, freeCellCoordinates, Color.white)
    {

    }
    public Move(bool isStrike, Vector2 freeCellCoordinates, Color color)
    {
        this.isStrike = isStrike;
        path.Add(freeCellCoordinates);
        this.color = color;
    }
}
