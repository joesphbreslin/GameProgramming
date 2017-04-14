using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	bool key, potion, sword;
	public int imageCount;
	static public int inventoryCount;
	public Image[] inventory;
	public Sprite[] sprites;
	public Sprite[] sprites_;
	public Slider healthSlider;
	public Text uiText;
	public GameObject[] items;


	float health;
	static public string textUi;
	// Use this for initialization
	void Awake ()
	{
		key = false; potion = false; sword = false;
		health = 100;
		textUi = "awake";
	}

	public void HealthUI (float val)
	{
		healthSlider.value = health;
	}

	public void TextUI ()
	{
		uiText.text = textUi;
	}

	void SwordObj ()
	{
		items [0].SetActive (false);
		items [1].SetActive (false);
		items [2].SetActive (sword);
	}

	void KeyObj ()
	{
		items [0].SetActive (key);
		items [1].SetActive (false);
		items [2].SetActive (false);
	}

	void PotionObj ()
	{
		if (potion)
		items [0].SetActive (false);
		items [1].SetActive (potion);
		items [2].SetActive (false);
	}

	void NoSelection ()
	{
		items [0].SetActive (false);
		items [1].SetActive (false);
		items [2].SetActive (false);

		for (int i = 0; i < 3; i++) {
			inventory [i].sprite = sprites [3] as Sprite;
		}
	}

	void SpriteMatch ()
	{
		if (inventoryCount == 1) {
			sprites_ [0] = sprites [3] as Sprite;
			sprites_ [1] = sprites [1] as Sprite;
			sprites_ [2] = sprites [3] as Sprite;
		} else if (inventoryCount == 2) {
			sprites_ [0] = sprites [0] as Sprite;
			sprites_ [1] = sprites [1] as Sprite;
			sprites_ [2] = sprites [3] as Sprite;
		} else {
			sprites_ [0] = sprites [0] as Sprite;
			sprites_ [1] = sprites [1] as Sprite;
			sprites_ [2] = sprites [2] as Sprite;
		}
	}

	void Inventory ()
	{
		if (inventoryCount > 0) {
			manageBools ();
			SpriteMatch ();
			if (Input.GetKeyDown (KeyCode.P) && imageCount < 2) {
				imageCount++;
			} else if (Input.GetKeyDown (KeyCode.P) && imageCount == 2) {
				imageCount = 0;
			}
			if (imageCount == 0) {
				PotionObj ();

				inventory [0].sprite = sprites_ [0] as Sprite;
				inventory [1].sprite = sprites_ [1] as Sprite;
				inventory [2].sprite = sprites_ [2] as Sprite;

			} else if (imageCount == 1) {
				
				SwordObj();
				inventory [0].sprite = sprites_ [1] as Sprite;
				inventory [1].sprite = sprites_ [2] as Sprite;
				inventory [2].sprite = sprites_ [0] as Sprite;
			} else if (imageCount == 2) {
				KeyObj();
				inventory [0].sprite = sprites_ [2] as Sprite;
				inventory [1].sprite = sprites_ [0] as Sprite;
				inventory [2].sprite = sprites_ [1] as Sprite;
			}
		} else {
			NoSelection ();
		}
	}

	void manageBools(){
		if (inventoryCount == 1) {
			potion = true;
		}
		if (inventoryCount == 2) {
			key = true;
		}
		if (inventoryCount == 3) {
			sword = true;
		}
	}

	void Update ()
	{
		TextUI ();
		healthSlider.value = health;
		if (Input.GetKeyDown (KeyCode.A)) {
			health--;
		}
		Inventory ();
		Debug.Log (inventoryCount);
	}
}


















