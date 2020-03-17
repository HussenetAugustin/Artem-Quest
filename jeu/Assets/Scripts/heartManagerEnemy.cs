using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class heartManagerEnemy : MonoBehaviour
{
    public GameObject[] hearts;
    public Sprite fullHeart;
    public Sprite halfFullHeart;
    public Sprite emptyHeart;
    public FloatValue heartContainer;
    public FloatValue playerCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }

    public void InitHearts()
    {
        for (int i = 0; i < heartContainer.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].GetComponent<SpriteRenderer>().sprite = fullHeart;
        }
    }

    public void UpdateHearts()
    {
        float tempHealth = playerCurrentHealth.RuntimeValue / 2;
        for (int i = 0; i < heartContainer.RuntimeValue; i++)
        {
            if (i <= tempHealth - 1)
            {
                hearts[i].GetComponent<SpriteRenderer>().sprite = fullHeart;
            }
            else if (i >= tempHealth)
            {
                hearts[i].GetComponent<SpriteRenderer>().sprite = emptyHeart;
            }
            else
            {
                hearts[i].GetComponent<SpriteRenderer>().sprite = halfFullHeart;
            }
        }
    }
}
