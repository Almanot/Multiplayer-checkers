using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Side
    {
        top,
        bottom
    }

    [SerializeField]
    private GameObject checkerPrefab;
    private GameField gameField;
    const int numberOfLines = 3; // how many lines will be busy by checkers

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameField = GameField.instance;
    }

    public void ArrangeCheckers(Side side, Player player)
    {
        // if player side is bottom, then placing checkers begin from zero coordinates
        int y = 0;
        // changeable marker to increase or decrease index after every cycle
        int marker = 1; 
        // line on which checkers placement will end.
        int lineNumber = numberOfLines; 
        
        // Change values to opposite if another side choosen
        if (side == Side.top)
        {
            y = gameField.Height;
            marker = -1;
            lineNumber = gameField.Height - numberOfLines;
        }

        //For not to double the code for different comparisons
        bool Comparison(int value1, int value2)
        {
            if (side == Side.top) // mean reverse
            {
                return value1 > value2;
            }
            else if (side == Side.bottom)
            {
                return value1 < value2;
            }
            else return false;
        }

        for (; Comparison(y, lineNumber); y = y + marker)
        {
            // if top side then count going in reverse
            int x = (side == Side.top) ? gameField.Width : 0;
            int columnNumber = (side == Side.top) ? 0 : gameField.Width;

            for (; Comparison(x, columnNumber); x = x + marker)
            {
                // This allow to place checkers only in black cells
                if (y % 2 == 0)
                {
                    // If line number is even then place chekers only in even columns
                    if (x % 2 == 0)
                    {
                        GameObject newChecker = Instantiate(checkerPrefab, new Vector2(x, y), checkerPrefab.transform.rotation);
                        //if (!gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>()))
                        //{
                        //    Debug.LogError("Unable to place checker " + newChecker.transform.position);
                        //    Destroy(newChecker);
                        //}
                        //else newChecker.GetComponent<Checker>().SetOwner(player);
                    }
                }
                // if line number is odd then place chekers only in odd columns
                else
                {
                    if (x % 2 != 0)
                    {
                        GameObject newChecker = Instantiate(checkerPrefab, new Vector2(x, y), checkerPrefab.transform.rotation);
                        //if (!gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>()))
                        //{
                        //    Debug.LogError("Unable to place checker " + newChecker.transform.position);
                        //    Destroy(newChecker);
                        //}
                        //else newChecker.GetComponent<Checker>().SetOwner(player);
                    }
                }
            }
        }
    }
}
