using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int health = 10;
    public int damage = 1;
    public float fireRate = 0.5f;
    public Text healthText;
    public Slider healthBar;

    public static GameManager gameManeger;
	// Use this for initialization
	void Start () {
        //PlayerPrefs.SetString("level", "ms");
        if (gameManeger == null)
        {
            gameManeger = this;
        }
        else
        {
            Destroy(gameObject);
        }
       // DontDestroyOnLoad(gameObject);
	}
    private void Update()
    {
        UpdateHealthBar();
       
    }

    public void UpdateHealthUi(int health)
    {
        healthText.text = health.ToString();
        healthBar.value = health;
    }

    public void UpdateHealthBar()
    {
        healthBar.maxValue = health;
    }
}
