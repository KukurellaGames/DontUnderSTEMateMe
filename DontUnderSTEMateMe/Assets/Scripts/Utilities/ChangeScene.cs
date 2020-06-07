using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    protected Scenes loadScene;
    [SerializeField] protected Canvas collectableList;



    public void onPointerClick()
    {
        LoadScene.Instance.loadScene(loadScene.ToString());
    }

    public void loadPreviousScene()
    {
        LoadScene.Instance.loadPreviousScene();
    }

    public void showCollectableList()
    {
        GetComponentInParent<Canvas>().enabled = false;
        collectableList.enabled = true;
    }
}

public enum Scenes
{
    MainScreen,
    Level01,
    Level02,
    Contact,
    GameOver
}
