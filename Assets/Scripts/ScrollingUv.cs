using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingUv : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Renderer bgRenderer;

    private void Update() {
        bgRenderer.material.mainTextureOffset += new Vector2(0,speed*Time.deltaTime);
    }
}
