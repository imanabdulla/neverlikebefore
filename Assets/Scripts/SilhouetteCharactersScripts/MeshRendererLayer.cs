using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRendererLayer : MonoBehaviour {

	private SkinnedMeshRenderer meshRend;

	public string sortingLayer = "Platforms&Ground";
	public int orderInLayer = 100;


	void Start () 
	{
		meshRend = this.GetComponent<SkinnedMeshRenderer> ();
		meshRend.sortingLayerName = sortingLayer;
		meshRend.sortingOrder = orderInLayer;
	}
}
