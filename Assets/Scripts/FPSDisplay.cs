using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class FPSDisplay : MonoBehaviour
{
    public float updateInterval = 0.5f;

    public bool showMedian = false;
    public float medianLearnrate = 0.05f;

    private float accum = 0;
    private int frames = 0;
    private float timeleft;
    private float currentFPS = 0;

    private float median = 0;
    private float average = 0;

    public float CurrentFPS => currentFPS;

    public float FPSMedian => median;

    public float FPSAverage => average;

    TextMeshProUGUI fpsText;

    void Start()
    {
        fpsText = GetComponent<TextMeshProUGUI>();
        timeleft = updateInterval;
    }

    void Update()
    {
            timeleft -= Time.deltaTime;
            accum += Time.timeScale/Time.deltaTime;
            ++frames;
         
            if( timeleft <= 0.0)
            {
                currentFPS = accum / frames;

                average += (Mathf.Abs(currentFPS) - average) * 0.1f;
                median += Mathf.Sign(currentFPS - median) * Mathf.Min(average * medianLearnrate, Mathf.Abs(currentFPS - median));

                float fps = showMedian ? median : currentFPS;
                fpsText.text = System.String.Format("{0:F2} FPS ({1:F1} ms)", fps, 1000.0f / fps); 

                timeleft = updateInterval;
                accum = 0.0F;
                frames = 0;
            }
    }

    public void ResetMedianAndAverage()
    {
        median = 0;
        average = 0;
    }
}