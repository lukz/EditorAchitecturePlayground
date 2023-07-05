using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ComplexMeshAvatar : AvatarBase
{
    [SerializeField, HideInInspector]
    private List<MeshRenderer> meshRenderers;
    
    public List<MeshRenderer> MeshRenderers => meshRenderers;
    
    private void OnValidate()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>().ToList();
    }
}