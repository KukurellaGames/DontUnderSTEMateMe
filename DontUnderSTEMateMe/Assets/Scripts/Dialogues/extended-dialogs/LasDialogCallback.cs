using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LasDialogCallback : MonoBehaviour
{
    [SerializeField] protected ChangeScene changeScene;
    [SerializeField] protected Image img;
    [SerializeField] protected float time = 0.1f;

   public void EndDialogueCallback()
    {
        StartCoroutine(myroutine());
    }

    private IEnumerator myroutine()
    {
        Debug.Log("Staring end routine...");
        img.enabled = true;
        while(img.color.a < 0.99f)
        {
            yield return new WaitForSeconds(time);
            Color c = img.color;
            c.a += 0.05f;
            img.color = c;
            Debug.Log(img.color.a + "is the current alpha");
        }
        Debug.Log("End routine...");
        changeScene.onPointerClick();
        Debug.Log("Scene Changed");
    }
}
