using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeManager : MonoBehaviour
{
    private int lifes = 1;
    [SerializeField]
    private TextMeshProUGUI lifeUI;
    [SerializeField]
    private GameObject mainUI;
    [SerializeField]
    private GameObject gameOverUI;

    private void Start()
    {
        lifeUI.text = lifes.ToString();
    }
    public void IncrementLife()
    {
        ++lifes;
        lifeUI.text = lifes.ToString();
    }

    public void DecrementLife()
    {
        --lifes;
        lifeUI.text = lifes.ToString();
    }

    public bool isDead()
    {
        DecrementLife();
        if (lifes <= 0)
        {
            Time.timeScale = 0f;
            gameOverUI.SetActive(true);
            mainUI.SetActive(false);
            return true;
        }
        else
        {
            return false;
        }
    }
}
