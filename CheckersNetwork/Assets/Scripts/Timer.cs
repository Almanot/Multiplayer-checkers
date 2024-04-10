using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timerDisplay;
    public int secondsReserve { get; private set; }
    float secondsLeft;
    bool paused = false;

    public void StopCountdown()
    {
        secondsLeft = 0;
    }
    public void PauseCountdown()
    {
        paused = true;
    }
    public void StartCountdown(int seconds = 360)
    {
        secondsReserve = seconds;
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        secondsLeft = secondsReserve;
        while (secondsLeft > 0)
        {
            if (paused) { yield return null; }
            secondsLeft -= 1;
            timerDisplay.text = secondsLeft.ToString();
            yield return new WaitForSecondsRealtime(1);
        }
    }
}
