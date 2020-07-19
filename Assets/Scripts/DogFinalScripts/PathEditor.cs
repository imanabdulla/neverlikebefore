using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathEditor : MonoBehaviour {

    public Color rayColor = Color.white;
    public List<Transform> pathObjs = new List<Transform>();
    Transform[] theArray;

    private void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        theArray = GetComponentsInChildren<Transform>();
        pathObjs.Clear();

        foreach (Transform pathobj in theArray)
        {
            if (pathobj != this.transform)
            {
                pathObjs.Add(pathobj);
            }

        }


        for (int i = 0; i < pathObjs.Count; i++)
        {

            Vector3 position = pathObjs[i].position;
            if (i > 0)
            {
                Vector3 previous = pathObjs[i - 1].position;
                Gizmos.DrawLine(previous, position);
              Gizmos.DrawWireSphere(position, 1f);
            }
        }


    }
}
