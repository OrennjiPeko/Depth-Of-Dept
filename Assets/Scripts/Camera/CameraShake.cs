using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 OriginalPos = transform.localPosition;

        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1) * magnitude;
            float y = Random.Range(-1f, 1) * magnitude;

            transform.localPosition = new Vector3(x, y, OriginalPos.z);

            elapsed += Time.deltaTime;

            Debug.Log("Camera shake");

            yield return null;
        }
        transform.localPosition = OriginalPos;
    }
}
