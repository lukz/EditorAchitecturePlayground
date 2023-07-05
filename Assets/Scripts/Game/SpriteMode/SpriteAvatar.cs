using UnityEngine;

public class SpriteAvatar : AvatarBase
{
    [SerializeField, HideInInspector]
    private SpriteRenderer spriteRenderer;
    
    public SpriteRenderer SpriteRenderer => spriteRenderer;
    
    private void OnValidate()
    {
        spriteRenderer ??= GetComponentInChildren<SpriteRenderer>();
    }
}
