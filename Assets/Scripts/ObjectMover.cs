using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    private Camera cam;
    public Vector3 screenPos;
    private Collider2D col;
    private bool mousePressed;
    public Vector3 startPos;
    private Vector3 offset;
    public float sortingLayer;
    public CurrentSortingLayer currentLayer;

    void Start()
    {
        cam = Camera.main;
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (col == Physics2D.OverlapPoint(mousePos))
            {
                mousePressed = true;
                startPos = transform.position;
                screenPos = cam.WorldToScreenPoint(transform.position);
                offset = transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

                StartCoroutine(Timer());
            }

            if (Input.GetMouseButtonUp(0))
            {
                mousePressed = false;
                currentLayer.currentLayer += 1;
            }

            if (Input.GetMouseButton(0))
            {
                if (mousePressed == true)
                {
                    var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
                    var curPosition = cam.ScreenToWorldPoint(curScreenSpace) + offset;
                    transform.position = curPosition;
                }
            }
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(7);

        transform.position = startPos;
        mousePressed = false;

    }
}
