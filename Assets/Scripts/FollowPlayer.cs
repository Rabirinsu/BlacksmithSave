using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject PlayerFollow;
    //   private Vector3 repos = new Vector3(0.1f, 0.8f, -1.5f);
    private Vector3 offset;
    public float rotatespeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - PlayerFollow.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = PlayerFollow.transform.position + offset;
        }

   
}
  
