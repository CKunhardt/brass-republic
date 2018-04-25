using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeManager : Singleton<FadeManager>
{

	public Image image;

	public void StartFade (bool fadeIn)
	{
		StartCoroutine (FadeImage (fadeIn));
	}

	public IEnumerator StartFadeAsync (bool fadeIn)
	{
		yield return FadeImage (fadeIn);
	}

	public void StartFadeOutAndIn ()
	{
		StartCoroutine (FadeOutIn ());
	}

	IEnumerator FadeImage (bool fadeIn)
	{
		if (fadeIn) {
			for (float i = 1; i >= 0; i -= Time.deltaTime) {
				image.color = new Color (1, 1, 1, i);
				yield return null;
			}
			image.gameObject.SetActive (false);
		} else {
			image.gameObject.SetActive (true);
			for (float i = 0; i <= 1; i += Time.deltaTime) {
				image.color = new Color (1, 1, 1, i);
				yield return null;
			}
		}
	}

	IEnumerator FadeOutIn ()
	{
		image.gameObject.SetActive (true);
		yield return FadeImage (false);
		yield return FadeImage (true);
		image.gameObject.SetActive (false);
	}
}
