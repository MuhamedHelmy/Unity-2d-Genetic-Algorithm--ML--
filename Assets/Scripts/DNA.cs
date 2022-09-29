using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA : MonoBehaviour
{
    // Start is called before the first frame update
    public float r;
    public float g;
    public float b;
    public float timeToDie=0;
    private bool _died = false;
    Collider2D col;
    SpriteRenderer render;
    void Start()
    {

        col = GetComponent<Collider2D>();
        render = GetComponent<SpriteRenderer>();
        if(!col ||!render)
        {
            Debug.Log("there is no collider or render");
        }
        render.color = new Color(r, g, b);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnMouseDown()
    {
        _died = true;
        Debug.Log("dead");
        render.enabled = false;
        col.enabled = false;
        timeToDie = PopulationManger.elapsed;

    }
}
