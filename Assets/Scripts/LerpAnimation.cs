// by META
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpAnimation : MonoBehaviour
{
    public AnimationCurve curve;
    public float animationTime = 0.2f;
    Coroutine fovCoroutine;

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Q))
            ChangeFOV(true);
        else if(Input.GetKeyDown(KeyCode.E))
            ChangeFOV(false);
    }

    public void ChangeFOV(bool enable)
    {

        if (fovCoroutine != null) StopCoroutine(fovCoroutine);
        fovCoroutine = StartCoroutine(LerpFOV(enable ? 30 : 60));

        IEnumerator LerpFOV(float targetValue)
        {

            float start = Time.unscaledTime;
            float startValue = Camera.main.fieldOfView;

            while (Time.unscaledTime < start + animationTime)
            {
                
                float completion = (Time.unscaledTime - start) / animationTime;
                Camera.main.fieldOfView = Mathf.Lerp(startValue, targetValue, curve.Evaluate(completion));
                yield return null;
            }

            Camera.main.fieldOfView = targetValue;
        }
    }
}
