using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
	public string name;
	public Sprite avatar;

	[TextArea (1, 4)]
	public string[] sentences;




}
