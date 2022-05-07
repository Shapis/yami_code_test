using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    private Coroutine _moveCouroutine;
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (_moveCouroutine is not null)
            {
                StopCoroutine(_moveCouroutine);
            }
            _moveCouroutine = StartCoroutine(MoveOverTime(this.gameObject, mousePosition));
        }
    }

    /// <summary>
    /// Receives a GameObject and moves it to the targetPosition over the durationInSeconds
    /// </summary>
    IEnumerator MoveOverTime(GameObject gameObject, Vector3 targetPosition, float durationInSeconds = 1f)
    {
        float timer = 0f;
        Vector3 initialPosition = gameObject.transform.position;
        while (gameObject.transform.position != targetPosition)
        {
            gameObject.transform.position = Vector3.Lerp(initialPosition, targetPosition, timer);
            timer += Time.deltaTime / durationInSeconds;
            yield return null;
        }
    }
}
