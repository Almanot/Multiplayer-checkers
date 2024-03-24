using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : ScriptableObject
{
    public bool isStrike { get; private set; }
    public List<Vector2> path = new List<Vector2>();
    public Color color { get; private set; }

    /// <summary>
    /// Data of move available for the cell
    /// </summary>
    /// <param name="isStrike">is this move are the strike to enemy checker?</param>
    /// <param name="freeCellCoordinates">Coordinates of the cell which will be reached after this move</param>
    public Move(bool isStrike, Vector2 freeCellCoordinates) : this(isStrike, freeCellCoordinates, Color.blue)
    {

    }
    /// <summary>
    /// Data of move available for the cell
    /// </summary>
    /// <param name="isStrike">is this move are the strike to enemy checker?</param>
    /// <param name="freeCellCoordinates">Coordinates of the cell which will be reached after this move</param>
    /// <param name="color">Color which will be used for paint the path on the game board</param>
    public Move(bool isStrike, Vector2 freeCellCoordinates, Color color)
    {
        this.isStrike = isStrike;
        path.Add(freeCellCoordinates);
        this.color = color;
    }
}
