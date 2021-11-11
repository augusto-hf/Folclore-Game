using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxIgnore : MonoBehaviour
{
    void FixedUpdate()
    {
        Physics2D.IgnoreLayerCollision(0, 6, true);
        Physics2D.IgnoreLayerCollision(8, 9, true);
    }
}
