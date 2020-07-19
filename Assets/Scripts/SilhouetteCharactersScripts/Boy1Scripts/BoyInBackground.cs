using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyInBackground : MonoBehaviour
{
    public GameObject boyPrefab;
	public float boySpeed = 10;
	private GameObject boyInstance;
    private GameObject mainCamera;
    private Camera camComponent;
	private bool isBoyAppeared = false;
	private bool isBoyDestroyed = false;



    private void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        camComponent = mainCamera.GetComponent<Camera>();
    }


    private void OnTriggerEnter2D(Collider2D col2d)
    {

		if (col2d.gameObject.tag == "Player" && isBoyAppeared == false)
        {
			boyInstance = Instantiate(boyPrefab, new Vector3(mainCamera.transform.position.x + (camComponent.orthographicSize * camComponent.aspect), this.transform.position.y, 0), Quaternion.identity);
			isBoyAppeared = true;
		}
    }


    private void Update()
    {
		if (isBoyAppeared == true && isBoyDestroyed == false)
        {
			if (boyInstance != null) 
			{
				boyInstance.transform.Translate(Vector3.left * Time.deltaTime * boySpeed);

				if (boyInstance.transform.position.x <= (mainCamera.transform.position.x - (camComponent.orthographicSize * camComponent.aspect)))
				{
					isBoyDestroyed = true;
					Destroy(boyInstance);
				}
			}
       }
    }
}
