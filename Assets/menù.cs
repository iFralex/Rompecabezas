using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menù : MonoBehaviour
{/*
    void Awake()
    {
        Vector2 resTarget = new Vector2(1920f, 1080f);
        Vector2 resViewport = new Vector2(Screen.width, Screen.height);
        Vector2 resNormalized = resTarget / resViewport;
        Vector2 size = resNormalized / Mathf.Max(resNormalized.x, resNormalized.y);
        Camera.main.rect = new Rect(default, size) { center = new Vector2(0.5f, 0.5f) };
    }
    */
    public void CambiaScena(int scena)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scena);
    }
}