using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Arranger : MonoBehaviour
{
    [SerializeField]
    private GameObject checkerPrefab;
    private GameField gameField;
    const int numberOfLines = 3;
    const int numberOfColumns = 4;

    // Start is called before the first frame update
    void Start()
    {
        gameField = GameField.instance;
    }

    void ArrangeCheckers()
    {
        for (int i = 0; i < numberOfLines; i++)
        {
            for(int j = 0; j < numberOfColumns; j++) 
            {
                if (i % 2 == 0)
                {
                    gameField.gameFieldSquares[i, j].myChecker = Instantiate(checkerPrefab);
                }
            }
        }
    }
}
