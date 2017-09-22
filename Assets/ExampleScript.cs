using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bubblebeam;

public class ExampleScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        var bubble = Bubble.Blower()
            .InLoop(Loop.Update)
            .ForKey(KeyCode.Space, KeyAction.Key_Down)
            .ForCustomBubble(new TimeBubble())
            .OnPop(OnPop)
            .Inflate();

        Beam.instance.AddBubble(bubble);
    }

    public void OnPop()
    {
        Debug.Log("The bubble popped!");
    }

    class TimeBubble : CustomBubble
    {
        public override bool ShouldPop()
        {
            return Mathf.CeilToInt(Time.time) % 3 == 0;
        }
    }
}
