using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    protected Scenes loadScene;



    public void onPointerClick()
    {
        Debug.Log("Change scene is triyng to change the scene");
        LoadScene.Instance.loadScene(loadScene.ToString());
    }

    public void loadPreviousScene()
    {
        LoadScene.Instance.loadPreviousScene();
    }
}

public enum Scenes
{
    MainScreen,
    Level01,
    Level02,
    Contact,
    GameOver,
    EpisodeCompleted
}
