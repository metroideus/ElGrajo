using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalObsBehaviour : MonoBehaviour
{
    public Vector2 middlePoint;
    public float minMoveSpeed = 2f;
    public float maxMoveSpeed = 2f;

    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Object.Destroy(gameObject,10f);
        transform.right = middlePoint - (Vector2)transform.position;
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
}
