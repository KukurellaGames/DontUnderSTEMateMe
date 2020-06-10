using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LoadScene : MonoBehaviour
{
    public string previousScene = " ";
    public static LoadScene Instance { get; private set; }

    [Range(0.01f, 0.1f)]
    protected float speedAppear = 0.5f;
    [Range(0.01f, 0.1f)]
    protected float speedDisappear = 0.5f;

    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
    {
        if(Instance == null)
        {
            Instance = this;
            //To be active in all scenes
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void loadScene(string nameScene)
    {
        previousScene = SceneManager.GetActiveScene().name;
        StartCoroutine(ShowLoadScene(nameScene));
    }

    public void loadPreviousScene()
    {
        StartCoroutine(ShowLoadScene(previousScene));
    }

    private IEnumerator ShowLoadScene(string nameScene)
    {
        //Load image
        SceneManager.LoadScene(nameScene);

        //Wait until the scene is loading
        while (!nameScene.Equals(SceneManager.GetActiveScene().name))
        {
            yield return null;
        }

        //CollectableLoad
        GameObject.FindGameObjectWithTag("CollectableContainer")?.GetComponent<CollectableContainer>()?.writeCollectables();
    }
}
