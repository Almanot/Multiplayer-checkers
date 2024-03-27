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
        Debug.Log(0 % 2);
    }

    public void ArrangeCheckers(Side side, Player player)
    {
        GameObject newChecker;
        if (side == Side.top)
        {
            newChecker = Instantiate(checkerPrefab, new Vector2(7, 7), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
            newChecker = Instantiate(checkerPrefab, new Vector2(5, 7), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
            newChecker = Instantiate(checkerPrefab, new Vector2(3, 7), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
            newChecker = Instantiate(checkerPrefab, new Vector2(1, 7), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
            newChecker = Instantiate(checkerPrefab, new Vector2(0, 6), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
            newChecker = Instantiate(checkerPrefab, new Vector2(2, 6), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
            newChecker = Instantiate(checkerPrefab, new Vector2(4, 6), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
            newChecker = Instantiate(checkerPrefab, new Vector2(6, 6), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
            newChecker = Instantiate(checkerPrefab, new Vector2(7, 5), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
            newChecker = Instantiate(checkerPrefab, new Vector2(5, 5), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
            newChecker = Instantiate(checkerPrefab, new Vector2(3, 5), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
            newChecker = Instantiate(checkerPrefab, new Vector2(1, 5), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
        }
        else
        {
            newChecker = Instantiate(checkerPrefab, new Vector2(0, 0), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
            newChecker = Instantiate(checkerPrefab, new Vector2(2, 0), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
            newChecker = Instantiate(checkerPrefab, new Vector2(4, 0), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
            newChecker = Instantiate(checkerPrefab, new Vector2(6, 0), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
            newChecker = Instantiate(checkerPrefab, new Vector2(1, 1), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
            newChecker = Instantiate(checkerPrefab, new Vector2(3, 1), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
            newChecker = Instantiate(checkerPrefab, new Vector2(5, 1), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
            newChecker = Instantiate(checkerPrefab, new Vector2(7, 1), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
            newChecker = Instantiate(checkerPrefab, new Vector2(0, 2), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
            newChecker = Instantiate(checkerPrefab, new Vector2(2, 2), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
            newChecker = Instantiate(checkerPrefab, new Vector2(4, 2), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
            newChecker = Instantiate(checkerPrefab, new Vector2(6, 2), checkerPrefab.transform.rotation);
            gameField.AddChecker(newChecker.transform.position, newChecker.GetComponent<Checker>());
        }

    }
}
