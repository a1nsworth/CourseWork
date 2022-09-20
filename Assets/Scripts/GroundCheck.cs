using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float groundDistance = 0.1f;
    public bool OnGround { get; set; }

    [SerializeField] private LayerMask[] layer = new LayerMask[2];

    private RaycastHit2D hitInfo;

    private bool IsOnGround(float distance)
    {
        return distance <= groundDistance;
    }

    private void FixedUpdate()
    {
        var position = transform.position;
        OnGround = Physics2D.Raycast(position, Vector3.down, groundDistance, layer[0]);

        Debug.Log(OnGround);
    }
}