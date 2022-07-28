using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float groundDistance = 0.1f;
    public bool OnGround { get; set; }

    [SerializeField] private LayerMask layer;

    private RaycastHit2D hitInfo;

    private bool IsOnGround(float distance)
    {
        return distance <= groundDistance;
    }

    private void FixedUpdate()
    {
        OnGround = Physics2D.Raycast(transform.position, Vector3.down, groundDistance, layer);
    }
}
