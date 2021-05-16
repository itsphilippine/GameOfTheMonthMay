using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickUp : MonoBehaviour
{
    public int value;

    public GameObject GoldFX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            //FindObjectOfType<GameManager>().AddGold(value);
            FindObjectOfType<GoldManager>().AddGold(value);
            GameManager gm = FindObjectOfType<GameManager>();

            Instantiate(GoldFX, transform.position, transform.rotation);
            
            Destroy(gameObject);

        }

    }

}