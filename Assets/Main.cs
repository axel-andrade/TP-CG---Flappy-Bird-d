using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {

	public GameObject cloud;
	public GameObject stone;
	public GameObject barrels;
	public GameObject bird;
	public Text myScore;

	public AudioClip soundFly;
	public AudioClip soundScore;
	public AudioClip soundCollision;

	bool begin;
	bool end;
	int score;

	void Start () {
		//criando a gravidade
		Physics.gravity = new Vector3 (0, -20.0F, 0);
	}

	void Update () {
		if (Input.anyKeyDown) {
			if (!end) {
				if (!begin) {
					//jogo começou
					begin = true;
					//começando em 1 segundo um objeto será criado a cada 0.77 segundos
					InvokeRepeating ("createObject", 1, 0.77F);
					//o passaro sofrerá gravidade
					bird.GetComponent<Rigidbody> ().useGravity = true;
					//fisica não afeta o corpo do passáro
					bird.GetComponent<Rigidbody> ().isKinematic = false;
					myScore.text = score.ToString ();
					myScore.fontSize = 100;
				}
				//voando com o passáro
				FlyBird ();
			}
		}
		//inicializando rotação do passáro
		bird.transform.rotation = Quaternion.Euler (bird.GetComponent<Rigidbody> ().velocity.y * -3, 90, 0);
	}

	//criando os objetos
	void createObject () {
		if (!end) {

			var opcode = Random.Range (1, 4);

			float randomPositionZ = Random.Range (-3.5f, 2.0f);
			float randomPositionY = Random.Range (4f, 7f);
			float randomRotationY = Random.Range (-0.0f, 360.0f);

			GameObject newObject = new GameObject ();

			switch (opcode) {
				case 1:
					newObject = (GameObject) Instantiate (stone);
					//garantindo que a pedra esteja no chão
					randomPositionY = 0;
					break;
				case 2:
					newObject = (GameObject) Instantiate (cloud);
					break;
				case 3:
					CreateBarrels ();
					break;
				default:
					break;
			}

			newObject.transform.position = new Vector3 (newObject.transform.position.x, newObject.transform.position.y + randomPositionY, newObject.transform.position.z + randomPositionZ);
			//Criando uma rotação de randomRotationY graus ao redor do eixo y
			newObject.transform.rotation = Quaternion.Euler (newObject.transform.rotation.x, randomRotationY, newObject.transform.rotation.z);

		}
	}

	//criando os canos
	void CreateBarrels () {
		if (!end) {
			GameObject objBarrels = new GameObject ();
 			objBarrels = (GameObject) Instantiate (barrels);
			float randomPositionY = Random.Range (2.0f, 4.2f);
			objBarrels.transform.position = new Vector3 (objBarrels.transform.position.x, randomPositionY, objBarrels.transform.position.z);
		}
	}

	//voo do passáro
	void FlyBird () {
		GetComponent<AudioSource> ().PlayOneShot (soundFly);

		bird.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		bird.GetComponent<Rigidbody> ().velocity = new Vector3 (0.0f, 9.8f, 0.0f);
	}

	//conquistando o ponto
	void GetPoint () {
		GetComponent<AudioSource> ().PlayOneShot (soundScore);
		score++;
		myScore.text = score.ToString ();
	}

	//finalizando o jogo
	void EndGame () {
		end = true;
		GetComponent<AudioSource> ().PlayOneShot (soundCollision);
		Invoke ("RecarregaCena", 2);
	}

	//Recarregando cena
	void RecarregaCena () {
		Application.LoadLevel ("MainScene");
	}

}