using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{

    public GameObject player;
    public Vector3 decalage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position =  new Vector3(transform.position.x + decalage.x, player.transform.position.y + decalage.y, player.transform.position.z + decalage.z);
    }
}
