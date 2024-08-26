using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Present one inventory item on UI
/// </summary>

public class UIItem : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TMP_Text countText;

    public event Action OnDrop;

    public void Create(Sprite sprite, int count)
    {
        image.sprite = sprite;
        ChangeCount(count);
    }

    public void ChangeCount(int count)
    {
        countText.text = count.ToString();
    }

    public void DropItem()
    {
        OnDrop?.Invoke();
    }
}
