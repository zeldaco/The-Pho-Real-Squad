using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public List<Image> hearts; // reference to heart asset in UI

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHeartsUI();
    }

    // Update is called once per frame
    void Update()
    {
        // logic for updating ui
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if the player collided with monster
        if (collision.gameObject.tag == "Monster")
        {
            LoseHeart();
        }

        // check if player collected a heart
        else if (collision.gameObject.tag == "Heart")
        {
            GainHeart();
            Destroy(collision.gameObject); // remove heart from the game
        }
    }

    void LoseHeart()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            UpdateHeartsUI();
        }

        if (currentHealth <= 0)
        {
            GameOver();
        }
        
    }

    void GainHeart()
    {
        
        currentHealth++;
        UpdateHeartsUI();
    
    }

    void UpdateHeartsUI()
    {
        // Loop through all heart images
        for (int i = 0; i < hearts.Count; i++)
        {
        // Enable heart image if i < currentHealth, otherwise disable it
            hearts[i].enabled = i < currentHealth;
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
