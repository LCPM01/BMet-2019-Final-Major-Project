using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_CameraShake : MonoBehaviour {

	public IEnumerator CamShake(float duration, float power)
	{
		Vector3 orignalPos = transform.localPosition;
		float timeElapsed = 0.0f;
		while(timeElapsed < duration)
		{
			float x = Random.Range(-0.5f, 0.5f) * power;
			float y = Random.Range(-0.5f, 0.5f) * power;
			transform.localPosition = new Vector3(x, y, orignalPos.z);
			timeElapsed += Time.deltaTime;
			yield return null;
		}
		transform.localPosition = orignalPos;
	}
	//transform.localPosition = orignalPos;
}
