using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bubblebeam;

public class Test : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        var bubble = Bubble.Blower()
            .InLoop(Loop.UPDATE)
            .ForKey(KeyCode.Space, KeyAction.KEY_DOWN)
            .ForCustomBubble(new Snarfer())
            .OnPop(OnPop)
            .Inflate();

        Beam.instance.AddBubble(bubble);
    }

    public void OnPop()
    {
        Debug.Log("Fuck yeah");
    }

    class Snarfer : CustomBubble
    {
		public override bool ShouldPop() {
			return Time.time % 3 == 0;
		}
    }
}
