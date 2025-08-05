using System;
using System.Collections;
using UnityEngine;

public static class AnimationUI
{
    
    // UI Functions Animations
    // TweenFloat is gonna be used only
    // for tweening Floats
    public static IEnumerator TweenFloat(
        float start,
        float end,
        float duration,
        Action<float> onUpdate,
        Func<float, float> easingFunction = null)
    {
        if (easingFunction == null)
        {
            easingFunction = EaseLinear;
        }
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            float easedT = easingFunction(t);
            onUpdate?.Invoke(Mathf.Lerp(start, end, easedT));
            yield return null;
        }
        onUpdate?.Invoke(end);
    }
    
    // TweenVec3 used to tween Vector 3
    public static IEnumerator TweenVec3(
        Vector3 start,
        Vector3 end,
        float duration,
        Action<Vector3> onUpdate,
        Func<float, float> easingFunction = null)
    {
        if (easingFunction == null)
        {
            easingFunction = EaseLinear;
        }

        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            float easedT = easingFunction(t);
            Vector3 current = Vector3.Lerp(start, end, easedT);
            onUpdate?.Invoke(current);
            yield return null;
        }
        onUpdate?.Invoke(end);
    }
    
    // Ease Functions for smooth animations
    public static float EaseLinear(float t)
    {
        return t;
    }

    public static float EaseInOutSine(float t)
    {
        return -(Mathf.Cos(Mathf.PI * t) - 1f) / 2f;
    }
    
    public static float EaseInQuad(float t)
    {
        return t * t;
    }

    public static float EaseOutQuad(float t)
    {
        return t * (2 - t);
    }

    public static float EaseInOutQuad(float t)
    {
        return t < 0.5f ? 2 * t * t : -1 + (4 - 2 * t) * t;
    }

    public static float EaseInCubic(float t)
    {
        return t * t * t;
    }

    public static float EaseOutCubic(float t)
    {
        t -= 1f;
        return t * t * t + 1f;
    }

    public static float EaseInOutCubic(float t)
    {
        return t < 0.5f 
            ? 4 * t * t * t 
            : (t - 1) * (2 * t - 2) * (2 * t - 2) + 1;
    }

    public static float EaseInQuart(float t)
    {
        return t * t * t * t;
    }

    public static float EaseOutQuart(float t)
    {
        t -= 1f;
        return 1 - t * t * t * t;
    }

    public static float EaseInOutQuart(float t)
    {
        return t < 0.5f 
            ? 8 * t * t * t * t 
            : 1 - 8 * Mathf.Pow(t - 1, 4);
    }

    public static float EaseInQuint(float t)
    {
        return t * t * t * t * t;
    }

    public static float EaseOutQuint(float t)
    {
        t -= 1f;
        return 1 + t * t * t * t * t;
    }
    
    public static float EaseInOutQuint(float t)
    {
        return t < 0.5f 
            ? 16 * t * t * t * t * t 
            : 1 + 16 * Mathf.Pow(t - 1, 5);
    }
    
}
