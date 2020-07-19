using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitPlayerPosition : MonoBehaviour
{
    public GameObject gameManager;
    private Rect sceneBoundaries;
    private float margin = 1f;
    void Start()
    {
        sceneBoundaries = gameManager.GetComponent<GameController>().GetSceneBoundaries();
    }
    void Update()
    {
        limitPosition();
    }
    public void limitPosition()
    {
        var x = Mathf.Clamp(transform.position.x, sceneBoundaries.xMin + margin, sceneBoundaries.xMax + margin);
        var y = Mathf.Clamp(transform.position.y, sceneBoundaries.yMin, sceneBoundaries.yMax);
        transform.position = new Vector3(x, y, 0);
    }
}
