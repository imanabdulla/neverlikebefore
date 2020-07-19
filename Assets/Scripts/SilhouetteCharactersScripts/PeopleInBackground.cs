using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleInBackground : MonoBehaviour
{
    public GameObject[] peoplePrefabs;
    public Vector2 delayTime = new Vector2(1, 5);
    public float peopleSpeed = 10;
    public int sortingOrder;
    public string layerName;
    private List<GameObject> LeftpeopleInstances;
    private List<GameObject> RightpeopleInstances;
    private GameObject peopleInstance;
    private GameObject mainCamera;
    private Camera camComponent;
    private bool isInstantiated = false;
    private int NUM_OF_PEOPLE_PREFABS;
    private const int MAX_NUMBER_PEOPLE = 10;


    private void Start()
    {
        LeftpeopleInstances = new List<GameObject>();
        RightpeopleInstances = new List<GameObject>();

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        camComponent = mainCamera.GetComponent<Camera>();
        NUM_OF_PEOPLE_PREFABS = peoplePrefabs.Length;
    }


    private void OnTriggerEnter2D(Collider2D col2d)
    {
        if (col2d.gameObject.tag == "Player" && !isInstantiated)
            InvokeRepeating("PeopleInstantiation", 1, UnityEngine.Random.Range(delayTime.x, delayTime.y));
    }


    public void PeopleInstantiation()
    {
        isInstantiated = true;

        if (LeftpeopleInstances.Count >= MAX_NUMBER_PEOPLE || RightpeopleInstances.Count >= MAX_NUMBER_PEOPLE)
        {
            CancelInvoke("PeopleInstantiation");
        }
        else
        {
            GameObject peopleprefab = peoplePrefabs[UnityEngine.Random.Range(0, NUM_OF_PEOPLE_PREFABS)];
            Vector3 peoplePrefabRightPosition = new Vector3(mainCamera.transform.position.x + (camComponent.orthographicSize * camComponent.aspect), this.transform.position.y, 0);
            Vector3 peoplePrefabLeftPosition = new Vector3(mainCamera.transform.position.x - (camComponent.orthographicSize * camComponent.aspect), this.transform.position.y, 0);

            switch (sortingOrder)
            {
                case 1:
                    if (layerName == "Buildings")
                        peoplePrefabRightPosition.y += 6f;
                    else if (layerName == "Platforms&Ground")
                        peoplePrefabRightPosition.y = this.transform.position.y;
                    break;
                case 3:
                    peoplePrefabRightPosition.y -= 20f; 
                    break;
                case 5:
                    peoplePrefabRightPosition.y += 18f;
                    break;
            }

            //Instatiate people in left position
            peopleInstance = Instantiate(peopleprefab, peoplePrefabRightPosition, Quaternion.identity);
            peopleInstance.transform.localScale = new Vector3(-Mathf.Abs(peopleInstance.transform.localScale.x), peopleInstance.transform.localScale.y, peopleInstance.transform.localScale.z);
            peopleInstance.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
            peopleInstance.GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
            LeftpeopleInstances.Add(peopleInstance);

            //Instatiate people in right position
            peopleInstance = Instantiate(peopleprefab, peoplePrefabLeftPosition, Quaternion.identity);
            peopleInstance.transform.localScale = new Vector3(Mathf.Abs(peopleInstance.transform.localScale.x), peopleInstance.transform.localScale.y, peopleInstance.transform.localScale.z);
            peopleInstance.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
            peopleInstance.GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
            RightpeopleInstances.Add(peopleInstance);
        }
    }


    private void Update()
    {
        for (int i = 0, k = 0; i < RightpeopleInstances.Count && k < LeftpeopleInstances.Count; i++, k++)
        {
            Debug.Log(peopleSpeed);
            RightpeopleInstances[i].transform.Translate(Vector3.right * peopleSpeed * Time.deltaTime);
            LeftpeopleInstances[i].transform.Translate(Vector3.left * peopleSpeed * Time.deltaTime);

            if ((RightpeopleInstances[i].transform.position.x >= (mainCamera.transform.position.x + (camComponent.orthographicSize * camComponent.aspect))))
                RightpeopleInstances[i].SetActive(false);

            if ((LeftpeopleInstances[k].transform.position.x <= (mainCamera.transform.position.x - (camComponent.orthographicSize * camComponent.aspect))))
                LeftpeopleInstances[k].SetActive(false);
        }
    }
}
