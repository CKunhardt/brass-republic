using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marley : NPC
{

	new void Start ()
	{
		base.Start ();
		anim.SetFloat ("input_y", 0f);
		anim.SetFloat ("input_x", -1f);
	}

}
