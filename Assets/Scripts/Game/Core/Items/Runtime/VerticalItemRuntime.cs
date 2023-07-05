using Game.Interfaces;
using UnityEngine;

public class VerticalItemRuntime : MonoBehaviour, IReadItemDescription
{
    private float speed;
    private Vector3 initialPos;
    private float lifetime;

    public void Setup(ItemDescription itemDescription)
    {
        speed = itemDescription.Speed;
        initialPos = transform.localPosition;
    }

    public void Update()
    {
        lifetime += Time.deltaTime;

        var xPos = initialPos.x + Mathf.Sin(lifetime * speed) * 2;

        transform.localPosition = new Vector3(xPos, initialPos.y, initialPos.z);
    }
}