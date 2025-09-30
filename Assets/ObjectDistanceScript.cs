using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDistanceScript : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        //float dis = Vector3.Distance(cube.transform.position, player.transform.position);
        //Debug.Log("‹——£:" + dis);
    }
}
