using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Renderer rend;
    public Color hoverColor;
    public float f = 3f;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.EnableKeyword("_EMISSION");
    }

    // The mesh goes red when the mouse is over it...
    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
        Color c = hoverColor * f;
        rend.material.SetColor("_EmissionColor", c);
    }

    // ...and the mesh finally turns white when the mouse moves away.
    void OnMouseExit()
    {
        rend.material.color = Color.white;
        rend.material.SetColor("_EmissionColor", Color.black);
    }
}
