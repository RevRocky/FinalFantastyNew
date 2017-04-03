using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadingBarScript : MonoBehaviour {


	AsyncOperation ao;
	public GameObject loadingScreenBG;
	public Slider progBar;
	public Text loadingText;

	public bool isFakeloadingBar = false;
	public float fakeIncrement = 0f;
	public float fakeTiming = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void loadLevel(){
		loadingScreenBG.SetActive (true);
		progBar.gameObject.SetActive (true);
		loadingText.gameObject.SetActive (true);
		loadingText.text = "loading...";

		if (!isFakeloadingBar) {
			StartCoroutine (LoadLevelRealProgress ());
		} else {
			StartCoroutine (LoadLevelFakeProgress ());
		}
	}

	IEnumerator LoadLevelRealProgress(){
		yield return new WaitForSeconds (1);

		ao = SceneManager.LoadSceneAsync (1);
		ao.allowSceneActivation = false;   //might want to display the message first

		while (!ao.isDone) {
			progBar.value = ao.progress;  //gives the value of bar


			if (ao.progress == 0.9f) {    //progress wont get any further until scene gets activated
				progBar.value = 1f;
				loadingText.text = "Press F to show respect";
				if(Input.GetKeyDown(KeyCode.F)){
					ao.allowSceneActivation = true;
				}
			}

			Debug.Log(ao.progress);
			yield return null;


		}

	}

	IEnumerator LoadLevelFakeProgress(){
		yield return new WaitForSeconds (1);

		while (progBar.value != 1f) {
			progBar.value += fakeIncrement;
			yield return new WaitForSeconds (fakeTiming); //fake timer
		}

		while(progBar.value == 1f){
			loadingText.text = "Press Space to Show Respect";
			if(Input.GetKeyDown(KeyCode.Space)){
				SceneManager.LoadScene("BigReveal");
			}

			yield return null;
		}
	}
}
