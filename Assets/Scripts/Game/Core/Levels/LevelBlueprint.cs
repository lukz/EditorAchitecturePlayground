using System.Linq;
using Game.Interfaces;
using UnityEngine;

public abstract class LevelBlueprint : MonoBehaviour
{
    public void Setup()
    {
        var items = GetComponentsInChildren<ItemDescription>().ToList();
        items.ForEach(InitializeItem);
    }

    private void InitializeItem(ItemDescription itemDesc)
    {
        itemDesc.InitRuntimeAvatar();
        
        var itemDescReaders = itemDesc.GetComponentsInChildren<IReadItemDescription>().ToList();
        itemDescReaders.ForEach(r => r.Setup(itemDesc));
    }
}
