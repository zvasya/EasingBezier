# EasingBezier functions for Unity 3D

Based on realization in https://github.com/mozilla/gecko-dev

And values from https://easings.net/

## Installing:
1) In Unity Package manager press + 
2) Select "Add package from git URL..."
3) Enter https://github.com/zvasya/EasingBezier.git

## Example

1) Get Y from X
```cs
    var f = EasingBezier.EaseInQuad.Get(0.3f);
```
2) Animate game object
```cs
    var tr = transform;
    var easing = EasingBezier.EaseOutSine;
    var t = 0f;
    while (t < 2.5f)
    {
      tr.localPosition = Vector3.Lerp(Vector3.zero, Vector3.one, easing.Get(t));
      yield return null;
      t += Time.deltaTime;
    }
    tr.localPosition = Vector3.one;
```
3) Build custom easing (use https://cubic-bezier.com as reference)
```cs
    var easing = new EasingBezier(0.36f, 1.33f, 0.93f, 1.26f);
```
