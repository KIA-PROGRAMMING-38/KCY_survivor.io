using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public void PopUp()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
}
