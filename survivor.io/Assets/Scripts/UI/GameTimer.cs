using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timer;
    private int min;
    private float sec;


    private void Start()
    {
        StartCoroutine(setTimer());
    }

    IEnumerator setTimer()
    {
        while (true) 
        {
            sec += Time.deltaTime;
            timer.text = string.Format("{0:D2}:{1:D2}", min, (int)sec);

            if (sec >= 60 )
            {
                min++;
                sec = 0;
            }
            yield return null;
        }
    }
}
