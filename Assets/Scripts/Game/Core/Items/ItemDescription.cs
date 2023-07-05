using System;
using UnityEditor.SceneManagement;
using UnityEngine;
using Utils;

[SelectionBase]
public class ItemDescription : MonoBehaviour
{
    [field: SerializeField] public ItemData ItemData { get; private set; }

    [field: SerializeField] public float Speed { get; private set; } = 1;
    
    public AvatarBase RuntimeAvatar { get; private set; }
    
#if UNITY_EDITOR
    [SerializeField, HideInInspector] private AvatarBase preview;
#endif
    

    public void InitRuntimeAvatar()
    {
        RemovePreview();

        if (ItemData != null)
        {
            RuntimeAvatar = CreateAvatar(true);
        }
    }
    
    private void UpdatePreview()
    {
        if (Application.isPlaying)
            return;

        // Make sure to delete the old debug preview hierarchy.
        RemovePreview();

        if (ItemData != null)
        {
            preview = CreateAvatar(false);
        }
    }

    private AvatarBase CreateAvatar(bool isRuntime)
    {
        var avatar = ObjectHelper.InstantiateOrPrefab(ItemData.avatar, transform);
        avatar.transform.localPosition = Vector3.zero;
        avatar.transform.localRotation = Quaternion.identity;

        if (!isRuntime)
        {
            avatar.gameObject.name = "Avatar Preview";
            avatar.gameObject.hideFlags = HideFlags.DontSave | HideFlags.NotEditable;
        }

        return avatar;
    }

    private void RemovePreview()
    {
        if (preview == null) 
            return;
        
        DestroyImmediate(preview.gameObject);
        preview = null;
    }

    private void OnValidate()
    {
        if (CheckIfIsPrefabStage())
        {
            UnityEditor.EditorApplication.delayCall += UpdatePreview;
        }
    }
    
    private bool CheckIfIsPrefabStage() => PrefabStageUtility.GetPrefabStage(gameObject) != null;
}
