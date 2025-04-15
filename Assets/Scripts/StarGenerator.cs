using UnityEngine;
using System.Collections;

public class StarGenerator : MonoBehaviour
{
    public GameObject starBg;  
    public int MaxStars;

    void Start()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));    
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));    
        for (int i = 0; i < MaxStars; ++i)
        {
            GameObject star = (GameObject)Instantiate(starBg);
            star.GetComponent<SpriteRenderer>().color = Color.white; 
            star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y)); 
            star.GetComponent<Stars>().speed = -(1f * Random.value + 0.5f);
            star.transform.parent = transform;    
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}