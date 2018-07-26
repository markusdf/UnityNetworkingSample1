using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour {

    private bool _isTouchingGround = false;

    public bool isTouchingGround
    {
        get
        {
            return _isTouchingGround;
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ground")
        {
            _isTouchingGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ground")
        {
            _isTouchingGround = false;
        }
    }

}
