using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContactBackManager : MonoBehaviour
{
    public void ContactBack()
    {
        SceneManager.LoadScene("MainScreen");
    }
}
