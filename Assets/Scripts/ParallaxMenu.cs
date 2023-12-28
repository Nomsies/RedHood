using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMenu : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    private float startpos, length;
    //[SerializeField] private GameObject camera;

    private void Start()
    {
        //startpos = transform.position.x;
        //length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float number = 0f;
        //float temp = number * (1 - scrollSpeed);
        float offset = number * scrollSpeed;

        //backgroundRenderer.transform.position = new Vector3(offset, backgroundRenderer.transform.position.y, backgroundRenderer.transform.position.z);
        transform.position = new Vector3(offset, transform.position.y, transform.position.z);

        //if (temp > startpos + length)
        //{
        //    startpos += length;
        //}
        //else if (temp < startpos - length)
        //{
        //    startpos -= length;
        //}

        number++;
    }
}
