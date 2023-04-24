using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class DropItem : MonoBehaviour
{
    public IObjectPool<DropItem> dropItempool;
    public float dropPow;
    private float rotatePow;
    private Vector3 dropPos;
    private Vector3 scalePos;
    private Vector3 rotatePos;
   
    public float scalePow;
    public RectTransform rectTransform;
    private WaitForSecondsRealtime wait;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }


    private void Start()
    {
        dropPos = new Vector3(0, -dropPow, 0);
        rotatePos = new Vector3(0, 0, 1);
        scalePos = new Vector3(-scalePow, -scalePow, 0);
        wait = new WaitForSecondsRealtime(0.1f);
        rotatePow = Random.Range(-100, 100);
    }
    public void SetPool(IObjectPool<DropItem> pool)
    {
        dropItempool = pool;
    }

    public void Ondead()
    {
        dropItempool.Release(this);
    }

    private void OnEnable()
    {
        StartCoroutine(scaleDown());
    }

    public void Update()
    {
        rectTransform.Translate(dropPos * Time.unscaledDeltaTime);
        rectTransform.rotation = Quaternion.Euler(rotatePos * rotatePow * Time.unscaledDeltaTime);

        if (rectTransform.localScale.x <= 0)
        {
            StopCoroutine(scaleDown());
            Ondead();
        }
    }

    private IEnumerator scaleDown()
    {
        while (true)
        { 
            rectTransform.localScale += scalePos;
            yield return wait;
        }
    }
}
