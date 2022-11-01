using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeBar : MonoBehaviour
{
    private float MAX_TIME = 50f;
    // -30 time per second
    private const float TIME_RATE = 0.5f;
    public float time;
    private Image timeBar;

    // Start is called before the first frame update
    void Start()
    {
        timeBar = GetComponent<Image>();
        time = MAX_TIME;
    }

    // Update is called once per frame
    void Update()
    {
        timeBar.fillAmount = time / MAX_TIME;
    }

    public float GetTime()
    {
        return time;
    }

    public void DecrementTime()
    {
        Debug.Log("DecrementTimeCalled");
        if (time > 0)
            time -= TIME_RATE;
    }

    public void IncrementTime()
    {
        if (time < MAX_TIME)
            time += TIME_RATE;
    }

    public bool IsTimeBarDepleted()
    {
        return time <= 0.0f;
    }

    public void GrowTimeBar()
    {
        MAX_TIME += 5;
        timeBar.rectTransform.rect.Set(timeBar.rectTransform.rect.x, timeBar.rectTransform.rect.y, timeBar.rectTransform.rect.width + 10, timeBar.rectTransform.rect.height);
    }
}
