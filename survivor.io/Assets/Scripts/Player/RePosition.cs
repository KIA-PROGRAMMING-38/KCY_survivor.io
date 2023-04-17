using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.UIElements;
using UnityEngine;

public class RePosition : MonoBehaviour
{
    private Vector3 movePos;
    private Vector3 moveMonster;
    private Vector3 moveItem;

    private void Start()
    {
        movePos = new Vector3(0f, 340f, 0f);
        moveMonster = new Vector3(0f, 230f, 0f);
        moveItem = new Vector3(0f, 230f, 0f);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
             return;
        
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 panelPos = GetComponent<Transform>().position;
        float panelDir = playerPos.y - panelPos.y;
        

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
            case "Item":
                 if (panelDir > 0)
                {
                    GetComponent<Transform>().position += moveItem;
                }
                else
                {
                    GetComponent<Transform>().position -= moveItem;
                }
                break;

        }
    }
}
