using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [Header("path")]
    [Range(1, 25)]
    [SerializeField] int pointsDensity = 2;
    [SerializeField] List<Transform> PathList = new List<Transform>();
    [SerializeField] List<Transform> bezierPath = new List<Transform>();

    private Transform[] objectArray;
    private int size;

    [Header("Gizmos")]
    public Color pathColor = Color.green;
    private void OnDrawGizmos()
    {
        Gizmos.color = pathColor;
        objectArray = GetComponentsInChildren<Transform>();
        PathList.Clear();
        foreach (Transform ts in objectArray)
        {
            if (ts != this.transform)
            {
                PathList.Add(ts);
            }
        }

        for (int i = 0; i < PathList.Count; i++)
        {
            Vector3 currentPosition = PathList[i].position;

            if (i > 0)
            {
                Vector3 perviousPosition = PathList[i - 1].position;

                Gizmos.DrawLine(perviousPosition, currentPosition);
            }

            Gizmos.DrawWireSphere(currentPosition, 0.25f);
        }
        if (PathList.Count % 2 == 0)
        {
            PathList.Add(PathList[PathList.Count - 1]);
            size = 2;

        }
        else
        {
            PathList.Add(PathList[PathList.Count - 1]);
            PathList.Add(PathList[PathList.Count - 1]);
            size = 3;
        }

        bezierPath.Clear();

        Vector3 lineStart = PathList[0].position;

        for (int i = 0; i < PathList.Count - size; i += 2)
        {
            for (int j = 0; j <= pointsDensity; j++)
            {
                Vector3 lineEnd = GetLastPoint(PathList[i].position, PathList[i + 1].position, PathList[i + 3].position, (float)j / pointsDensity);

                Gizmos.color = Color.blue;
                Gizmos.DrawLine(lineStart, lineEnd);

                lineStart = lineEnd;
            }
        }
    }
    Vector3 GetLastPoint(Vector3 point01, Vector3 point02, Vector3 point03,  float t)
    {
        return Vector3.Lerp(Vector3.Lerp(point01, point02, t), Vector3.Lerp(point02, point03, t), t);
    }

}
