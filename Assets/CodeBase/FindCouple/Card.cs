using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite backSprite;
    private Sprite frontSprite;
    private int type;
    public int Type => type;
    /// <summary>
    /// TODO : переработать это
    /// </summary>
    public bool isSet;


    private bool isClosed = true;
    public bool IsClosed => isClosed;
    public void CloseCard()
    {
        isClosed = true;
        spriteRenderer.sprite = backSprite;
    }

    public void OpenCard()
    {
        isClosed = false;
        spriteRenderer.sprite = frontSprite;
    }

    public void SetFrontSprite(Sprite sprite)
    {
        frontSprite = sprite;
    }
    public void SetBackSprite(Sprite sprite)
    {
        backSprite = sprite;
    }


    public void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
    public void SetType(int type)
    {
        this.type = type;   
    }
}
