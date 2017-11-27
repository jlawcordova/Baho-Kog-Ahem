using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text3DFront : MonoBehaviour {

	public int SortOrder;

	// Use this for initialization
	void Awake () {
		gameObject.GetComponent<Renderer>().sortingLayerName = "Banner"; 
		gameObject.GetComponent<Renderer>().sortingOrder = SortOrder; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
