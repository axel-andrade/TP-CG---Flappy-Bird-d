using UnityEngine;
using System.Collections;

public class MoveFloor : MonoBehaviour {

	private float velocity = -0.50f;
	public Material materialFloor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//valor em segundos desde que o jogo começou x velocidade
		float offset = Time.time * velocity;
		materialFloor.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
