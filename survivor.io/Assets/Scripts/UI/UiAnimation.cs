using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UiAnimation : MonoBehaviour
{
    private Animator ani;
   
    private void Awake()
    {
        ani = GetComponent<Animator>();
    }


    private void OnEnable()
    {
        ani.SetTrigger("ChangeColor");
    }


}
