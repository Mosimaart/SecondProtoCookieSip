using UnityEngine;
using System.Collections;

public class ArrowMover : MonoBehaviour
{
    public float moveDuration = 33f;
    public float delayBeforeStart = 4f;

    public float startX = 8f;
    public float endX = -8f;

    private float fixedY;

    void Start()
    {
        fixedY = transform.position.y;
        StartCoroutine(MoveLoop());
    }

    IEnumerator MoveLoop()
    {
        while (true)
        {
            // Wait before starting
            yield return new WaitForSeconds(delayBeforeStart);

            float elapsed = 0f;

            while (elapsed < moveDuration)
            {
                float t = elapsed / moveDuration;

                float newX = Mathf.Lerp(startX, endX, t);
                transform.position = new Vector3(newX, fixedY, 0f);

                elapsed += Time.deltaTime;
                yield return null;
            }

            // Snap exactly to end
            transform.position = new Vector3(endX, fixedY, 0f);

            // Reset instantly to start
            transform.position = new Vector3(startX, fixedY, 0f);
        }
    }
}