using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarsController : MonoBehaviour
{
    public WheaterPhase actualWheaterPhase = null;
    public float minPositon = 100f;
    public float maxPosition = 970f;

    // Update is called once per frame
    void Update()
    {
        

        if (actualWheaterPhase != null)
        {

            if (!(transform.position.y < minPositon && actualWheaterPhase.upOrDown == -1)
                && !(transform.position.y > maxPosition && actualWheaterPhase.upOrDown == 1))
            {
                float newPositionY = actualWheaterPhase.speed * actualWheaterPhase.upOrDown * Time.deltaTime;
                transform.Translate(Vector3.up * newPositionY);
            }

            
            
        }

    }
}
