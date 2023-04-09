using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RePosition : MonoBehaviour
{
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
             return;
        
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 panelPos = GetComponent<Transform>().position;
        float asdf = playerPos.y - panelPos.y;
        Vector3 movePos = new Vector3(0f, 340, 0f);

       
        if (asdf > 0)
        {
            GetComponent<Transform>().position += movePos;
        }
        else
        {
            GetComponent<Transform>().position -= movePos;
        }

        
    }
}
