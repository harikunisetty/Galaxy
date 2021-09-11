using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathOne : MonoBehaviour
{
    [Header("Path")]
    [Range(1, 25)]
    [SerializeField] int pointsDensity = 2;
    [SerializeField] List<Transform> pathList = new List<Transform>();
    [SerializeField] List<Transform> bezierPath = new List<Transform>();
    private Transform[] objectArray;
    private int size;

    [Header("Gizmos")]
    [SerializeField] Color pathColor = Color.gray;

    private void OnDrawGizmos()
    {
        Gizmos.color = pathColor;

        // Object Array
        objectArray = GetComponentsInChildren<Transform>();

        // Add Objects to Path List
        pathList.Clear();

        foreach (Transform ts in objectArray)
        {
            if (ts != this.transform)
            {
                pathList.Add(ts);
            }
        }

        // Draw Line between points
        for (int i = 0; i < pathList.Count; i++)
        {
            Vector3 currentPosition = pathList[i].position;

            if (i > 0)
            {
                Vector3 perviousPosition = pathList[i - 1].position;

                Gizmos.DrawLine(perviousPosition, currentPosition);
            }

            Gizmos.DrawWireSphere(currentPosition, 0.25f);
        }

        // Curving the path
        if (pathList.Count % 2 == 0)
        {
            // Even
            pathList.Add(pathList[pathList.Count - 1]);
            size = 2;
        }
        else
        {
            // Odd
            pathList.Add(pathList[pathList.Count - 1]);
            pathList.Add(pathList[pathList.Count - 1]);
            size = 3;
        }

        bezierPath.Clear();

        Vector3 lineStart = pathList[0].position;

        for (int i = 0; i < pathList.Count - size; i += 2)
        {
            for (int j = 0; j <= pointsDensity; j++)
            {
                Vector3 lineEnd = GetLastPoint(pathList[i].position, pathList[i + 1].position, pathList[i + 3].position, (float)j / pointsDensity);

                Gizmos.color = Color.blue;
                Gizmos.DrawLine(lineStart, lineEnd);

                lineStart = lineEnd;
            }
        }
    }

    Vector3 GetLastPoint(Vector3 point01, Vector3 point02, Vector3 point03, float t)
    {
        return Vector3.Lerp(Vector3.Lerp(point01, point02, t), Vector3.Lerp(point02, point03, t), t);
    }
}
