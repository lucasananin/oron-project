using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour
{
    /*[SerializeField]
    private int _particleID;*/

	void Start ()
    {
        /*if (_particleID == 0)
        {
            Destroy(this.gameObject, 0.25f);
        }
        else if (_particleID == 5)
        {
            Destroy(this.gameObject, 2.0f);
        }else if (_particleID == 10)
        {
            Destroy(this.gameObject, 2.0f);
        }*/

        Destroy(this.gameObject, 2.0f);
    }
}
