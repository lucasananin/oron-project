using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTest : MonoBehaviour
{
    Animator anim;

	void Start ()
    {
        anim = GetComponent<Animator>();
    }

	void Update ()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Velocidade", move);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Pulo");
        }
    }
}
