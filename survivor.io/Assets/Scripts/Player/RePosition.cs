using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.UIElements;
using UnityEngine;

public class RePosition : MonoBehaviour
{
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
             return;
        
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 panelPos = GetComponent<Transform>().position;
        float panelDir = playerPos.y - panelPos.y;
        Vector3 movePos = new Vector3(0f, 340f, 0f);
        Vector3 moveMonster = new Vector3(0f, 230f, 0f);

        switch (transform.tag)
        {
            case "Ground":

                if (panelDir > 0)
                {
                    GetComponent<Transform>().position += movePos;
                }
                else
                {
                    GetComponent<Transform>().position -= movePos;
                }
                break;

            case "Monster":

                if (panelDir > 0)
                {
                    GetComponent<Transform>().position += moveMonster;
                }
                else
                {
                    GetComponent<Transform>().position -= moveMonster;
                }
                break;
        }
    }
}
