using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrajoController : MonoBehaviour
{
    public float flySpeed = 2f;
    public float fallMultiplayer = 3f;
    public AudioClip flapSound;
    
    private Rigidbody2D rb;
    private AudioSource audioS;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioS = GetComponent<AudioSource>();
    }

    void Update()
    {

        float moveY = Input.GetAxis("Vertical");
        if (moveY > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, moveY * flySpeed);
        }
        else if (moveY < 0)
        {
            rb.velocity = new Vector2( rb.velocity.x, (moveY * flySpeed * fallMultiplayer));
        }
    }

    public void PlayFlap()
    {
        audioS.PlayOneShot(flapSound);
    }
}
