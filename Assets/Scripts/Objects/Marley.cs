using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marley : NPC
{

	new void Start ()
	{
		base.Start ();
		anim.SetFloat ("input_x", -1f);
	}

}
