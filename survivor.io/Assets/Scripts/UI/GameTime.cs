using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    private Text timer;

    private void Awake()
    {
        timer = GetComponent<Text>();
    }
  

   
    void Update()
    {
      //  timer.text = GameManager.instance.gameTimer.ToString();
    }
}
