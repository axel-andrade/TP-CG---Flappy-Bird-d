using UnityEngine;
using System.Collections;

public class DeleteObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("Delete", 1.5f);
	} 

	void Delete(){

		Destroy(this.gameObject);

	}
}
