using UnityEngine;

public static class TransformExtension
{
    public static void ClearChildren(this Transform that)
    {
        // foreach doesnt work, skips half of the children
        for (int i = that.childCount - 1; i >= 0; i--)
        {
            var target = that.GetChild(i)?.gameObject;

            if (Application.isPlaying)
            {
                GameObject.Destroy(target);
            }
            else
            {
                // editor wants DestroyImmediate instead of Destroy
                GameObject.DestroyImmediate(target);
            }
        }
    }
}
