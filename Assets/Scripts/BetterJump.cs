using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    // Start is called before the first frame update

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public Rigidbody rB;
    void Start()
    {
        rB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rB.velocity.y < 0)
        {
            rB.velocity += Vector3.up * Physics.gravity.y  * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(rB.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rB.velocity += Vector3.up * Physics.gravity.y  * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
