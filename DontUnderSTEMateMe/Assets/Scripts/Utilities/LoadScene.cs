using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    
    public static LoadScene Instance { get; private set; }

    public Image loadImage;
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
            loadImage.gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void loadScene(string nameScene)
    {
        StartCoroutine(ShowLoadScene(nameScene));
    }

    private IEnumerator ShowLoadScene(string nameScene)
    { 
        loadImage.gameObject.SetActive(true);
        Color c = loadImage.color;

        c.a = 0.0f;

        //Se hará un fundido para que se abra cuando esté totalmente visible
        while (c.a < 1)
        {
            loadImage.color = c;
            c.a += speedAppear;
            yield return null;
        }

        //Load image
        SceneManager.LoadScene(nameScene);

        //Wait until the scene is loading
        while (!nameScene.Equals(SceneManager.GetActiveScene().name))
        {
            yield return null;
        }

        //When scene is loaded, the load image disappears
        while (c.a > 0)
        {
            loadImage.color = c;
            c.a -= speedDisappear;
            yield return null;
        }
        loadImage.gameObject.SetActive(false);
    }
}
