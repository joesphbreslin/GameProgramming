using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {
	public int imageCount;
	public Image[] inventory;
	public Sprite[] sprites;
	public Slider healthSlider;
	public GameObject[] items;
	float health;
	// Use this for initialization
	void Awake () {
		health = 100;

	}
		
	public void HealthUI(float val)
	{
		healthSlider.value = health;
	}

	void Inventory()
	{
		if (Input.GetKeyDown (KeyCode.P) && imageCount < 2) {
			imageCount++;
		} else if (Input.GetKeyDown (KeyCode.P) && imageCount == 2) {
			imageCount = 0;
		}

		if (imageCount == 0) {
			inventory [0].sprite = sprites [0] as Sprite;
			inventory [1].sprite = sprites [1] as Sprite;
			inventory [2].sprite = sprites [2] as Sprite;
			items [0].SetActive (false);
			items [1].SetActive (true);
			items [2].SetActive (false);
		} else if (imageCount == 1) {
			inventory [0].sprite = sprites [1] as Sprite;
			inventory [1].sprite = sprites [2] as Sprite;
			inventory [2].sprite = sprites [0] as Sprite;
			items [0].SetActive (false);
			items [1].SetActive (false);
			items [2].SetActive (true);
		} else if (imageCount == 2) {
			inventory [0].sprite = sprites [2] as Sprite;
			inventory [1].sprite = sprites [0] as Sprite;
			inventory [2].sprite = sprites [1] as Sprite;
			items [0].SetActive (true);
			items [1].SetActive (false);
			items [2].SetActive (false);
		}
	}


	// Update is called once per frame
	void Update () {
		healthSlider.value = health;
		if (Input.GetKeyDown (KeyCode.A)) {
			health--;
		}
		Inventory ();
		Debug.Log (imageCount);
	}
}
