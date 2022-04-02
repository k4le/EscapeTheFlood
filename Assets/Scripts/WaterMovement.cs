using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    Vector2 orginalPosition;
    RectTransform RectTransform;
    float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        RectTransform = GetComponent<RectTransform>();
        orginalPosition = RectTransform.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Mathf.Sin(Time.deltaTime) * 400);
        RectTransform.transform.position = new Vector2(orginalPosition.x + Mathf.Cos(t) * 5, orginalPosition.y + Mathf.Sin(t)*10);
        t += Time.deltaTime;
    }
}
