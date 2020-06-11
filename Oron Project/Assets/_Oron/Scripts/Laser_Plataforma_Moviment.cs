using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Plataforma_Moviment : MonoBehaviour
{
    // Variaveis;
    public enum TipoMovimento { Horizontal, Vertical, Foward };
    public TipoMovimento movimento;
    public float minimum = -1.0F;
    public float maximum = 1.0F;
    public float posX = 0, posY = 0, posZ = 0;
    private float t = 0.0f; // starting value for the Lerp
    public float speed = 1;

    void Update()
    {
        if (movimento == TipoMovimento.Horizontal)
        {
            MovimentoHorizontal();
        }
        else if (movimento == TipoMovimento.Vertical)
        {
            MovimentoVertical();
        }
        else if(movimento == TipoMovimento.Foward)
        {
            MovimentoFoward();
        }
    }

    void MovimentoHorizontal()
    {
        // animate the position of the game object...
        transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), posY, posZ);

        // .. and increase the t interpolater
        t += 0.5f * Time.deltaTime * speed;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }

    void MovimentoVertical()
    {
        // animate the position of the game object...
        transform.position = new Vector3(posX, Mathf.Lerp(minimum, maximum, t), posZ);

        // .. and increase the t interpolater
        t += 0.5f * Time.deltaTime * speed;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }

    void MovimentoFoward()
    {
        // animate the position of the game object...
        transform.position = new Vector3(posX, posY, Mathf.Lerp(minimum, maximum, t));

        // .. and increase the t interpolater
        t += 0.5f * Time.deltaTime * speed;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}
