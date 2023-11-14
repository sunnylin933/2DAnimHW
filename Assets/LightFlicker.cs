using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    Light2D lt;
    float goalIntensity = 1f;
    float currentTime = 0f;
    float timeMax = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > timeMax)
        {
            goalIntensity = Random.Range(0.75f, 1f);
            currentTime = 0f;
        }
        lt.intensity = Mathf.Lerp(lt.intensity, goalIntensity, 0.01f);
    }
}
