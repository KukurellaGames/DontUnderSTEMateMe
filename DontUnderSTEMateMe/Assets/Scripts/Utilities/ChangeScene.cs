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
        LoadScene.Instance.loadScene(loadScene.ToString());
    }
}

public enum Scenes
{
    MainScreen,
    Level01,
    Level02
}
