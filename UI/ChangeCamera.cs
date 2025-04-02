using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Camera Camera;
    public Transform RoomMiddlePoint;
    public float transitionSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(SmoothTransition());
        }
    }

    private IEnumerator SmoothTransition()
    {
        Vector3 targetPosition = RoomMiddlePoint.position;
        while (Vector3.Distance(Camera.transform.position, targetPosition) > 0.1f)
        {
            Camera.transform.position = Vector3.MoveTowards(Camera.transform.position, targetPosition, transitionSpeed * Time.deltaTime);
            yield return null;
        }
        Camera.transform.position = targetPosition;
    }
}