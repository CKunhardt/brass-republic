using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeManager : Singleton<FadeManager>
{

	public Image image;

	public void StartFade (bool fadeOut)
	{
		StartCoroutine (FadeImage (fadeOut));
	}

	IEnumerator FadeImage (bool fadeOut)
	{
		if (fadeOut) {
			for (float i = 1; i >= 0; i -= Time.deltaTime) {
				image.color = new Color (1, 1, 1, i);
				yield return null;
			}
		} else {
			for (float i = 0; i <= 1; i += Time.deltaTime) {
				image.color = new Color (1, 1, 1, i);
				yield return null;
			}
		}
	}
}
