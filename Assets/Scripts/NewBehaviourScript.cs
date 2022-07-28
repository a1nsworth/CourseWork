using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Left,
    Right,
    Jump
}

public class NewBehaviourScript : MonoBehaviour
{

    public Dictionary<KeyCode, State> inputs = new Dictionary<KeyCode, State>();

    private void Update()
    {
        inputs.Clear();

        if (Input.GetKey(KeyCode.A))
        {
            if (!inputs.ContainsKey(KeyCode.A))
                inputs.Add(KeyCode.A, State.Left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (!inputs.ContainsKey(KeyCode.D))
                inputs.Add(KeyCode.D, State.Right);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!inputs.ContainsKey(KeyCode.LeftArrow))
                inputs.Add(KeyCode.LeftArrow, State.Left);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!inputs.ContainsKey(KeyCode.RightArrow))
                inputs.Add(KeyCode.RightArrow, State.Right);
        }
    }
}
