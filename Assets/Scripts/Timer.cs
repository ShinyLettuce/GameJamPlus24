using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    float startTime = 99;

    float timeLeft;

    bool timerOn = true;
    bool timeUp = false;

    TextMeshProUGUI timerTxt;

    public bool TimeUp() => timeUp;

    void Start()
    {
        timeLeft = startTime;
        timerTxt = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(timerOn)
        {
            if(timeLeft > 0f)
            {
                timeLeft -= Time.deltaTime;
            }
            else
            {
                timeUp = true;
                timeLeft = 0f;
            }
            updateTimerVisual(timeLeft);
        }
    }

    void updateTimerVisual(float currentTime)
    {
        currentTime = Mathf.Ceil(currentTime);
        timerTxt.SetText("{0}", currentTime);
    }
}
