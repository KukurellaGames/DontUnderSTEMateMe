using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollableMaterial : MonoBehaviour
{
    Material mat;
    [SerializeField] protected float scrollSpeed = 0.2f;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float offset = Time.time * scrollSpeed;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
