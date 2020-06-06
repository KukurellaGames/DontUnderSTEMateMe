using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeManager : MonoBehaviour
{
    const int initialLifes = 2;
    private int lifes = 2;
    [SerializeField]
    private TextMeshProUGUI lifeUI;
    private ChangeScene _chScene;

    public void setInitialLifes()
    {
        lifes = initialLifes;
        lifeUI.text = lifes.ToString();
    }

    private void Start()
    {
        lifeUI.text = lifes.ToString();
        _chScene = GetComponent<ChangeScene>();
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
            _chScene.onPointerClick();
            //Time.timeScale = 0f;
            return true;
        }
        else
        {
            return false;
        }
    }
}
