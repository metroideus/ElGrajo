using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RandomMover : MonoBehaviour
{
    public float moveRange = 5.0f; // Rango de movimiento
    public float moveDuration = 100.0f; // Duración del movimiento

    void Start()
    {
        MoveObjectRandomly();
    }

    void MoveObjectRandomly()
    {
        // Generar una posición aleatoria dentro del rango especificado
        float randomX = Random.Range(-moveRange, moveRange);
        Vector3 newPosition = new Vector3(randomX, transform.position.y, transform.position.z);

        // Mover el objeto a la nueva posición
        transform.DOMove(newPosition, moveDuration).OnComplete(MoveObjectRandomly);
    }
}
