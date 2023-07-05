using UnityEngine;

public class MeshAvatar : AvatarBase
{
    [SerializeField, HideInInspector]
    private MeshRenderer meshRenderer;
    
    public MeshRenderer MeshRenderer => meshRenderer;
    
    private void OnValidate()
    {
        meshRenderer ??= GetComponentInChildren<MeshRenderer>();
    }
}