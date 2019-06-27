using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

	public GameObject mainCamera;

	//OnTriggerEnter é chamado quando o GameObject colide com outro GameObject .
	void OnTriggerEnter(Collider objeto)
	{	
		//se o passáro colidiu com um objeto com o tag finish o jogo deve ser encerrado
		if(objeto.gameObject.tag == "Finish")
		{   
			//zerando velocidade do passáro
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			//jogando o passáro pra trás
			GetComponent<Rigidbody>().velocity = new Vector3(-15.0f, 15.0f, 0.0f);
			//girando o passáro
			GetComponent<Rigidbody>().AddTorque(new Vector3(-100,-100,-100));
			
			mainCamera.SendMessage("EndGame");
		}
	}

	void OnTriggerExit(Collider objeto)
	{
		if(objeto.gameObject.tag == "GameController")
		{
			Destroy(objeto.gameObject);
			mainCamera.SendMessage("GetPoint");
		}
	}
}
