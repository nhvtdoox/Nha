using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{
    [SerializeField]  List<Light> lights;
    int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        for(var i = 0; i<lights.Count; i++)
        {

            lights[i].gameObject.SetActive(true);
        }
    }

    public void LightPressed()
    {
        if (state == 0)
        {
            for (var i = 0; i < lights.Count; i++)
            {

                lights[i].gameObject.SetActive(false);
            }
            
        }
        else if (state == 1)
        {
            lights[0].gameObject.SetActive(true);
        }
        else if (state == 2)
        {
            lights[0].gameObject.SetActive(false);
            lights[1].gameObject.SetActive(true);
        }
        else if (state == 3)
        {
            lights[1].gameObject.SetActive(false);
            lights[2].gameObject.SetActive(true);
        }
        else if (state == 4)
        {
            lights[0].gameObject.SetActive(true);
            lights[1].gameObject.SetActive(true);
            lights[2].gameObject.SetActive(false);
        }
        else if (state == 5)
        {
            lights[0].gameObject.SetActive(true);
            lights[1].gameObject.SetActive(false);
            lights[2].gameObject.SetActive(true);
        }
        else if (state == 6)
        {
            lights[0].gameObject.SetActive(false);
            lights[1].gameObject.SetActive(true);
            lights[2].gameObject.SetActive(true);
        }
        else if (state == 7)
        {
            lights[0].gameObject.SetActive(true);
            lights[1].gameObject.SetActive(true);
            lights[2].gameObject.SetActive(true);
        }
        state ++;
        if(state > 7)
        {
            state = 0;
        }
    }
}
