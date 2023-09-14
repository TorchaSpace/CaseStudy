using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    Vector3 controlPos1;
    Vector3 controlPos2;
    [SerializeField] private float speed = 3;

    public void StartMove(Vector3 startPos, Vector3 endPos, Vector3 controlPos1, Vector3 controlPos2)
    {
        this.startPos = startPos;
        this.endPos = endPos;
        this.controlPos1 = controlPos1;
        this.controlPos2 = controlPos2;

        float duration = Vector3.Distance(startPos, endPos) / speed;

        StartCoroutine(Movement(duration));
    }

    private Vector3 CalculateBezierPoint(float t)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * startPos + 3 * uu * t * controlPos1 + 3 * u * tt * controlPos2 + ttt * endPos;
        return p;
    }

    IEnumerator Movement(float duration)
    {
        float timePassed = 0;

        while(timePassed <= duration)
        {
            transform.position = CalculateBezierPoint(timePassed / duration);
            timePassed += Time.deltaTime / duration;

            yield return null;
        }

        
    }
}
