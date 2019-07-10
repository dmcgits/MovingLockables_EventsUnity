using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class IconSwitcher : MonoBehaviour {
  [SerializeField]
  protected SpriteAtlas _atlas;

  protected SpriteRenderer _renderer;
  // Awake() runs before Start(). Use it to get listeners ready as early as possible.

  private void Awake()
  {
    MovingGameModel.OnIconUpdate += IconUpdateHandler;
    _renderer = gameObject.GetComponent<SpriteRenderer>();
  }

  private void IconUpdateHandler( string newIconName )
  {
    //Debug.Log(gameObject.name + "newIconName: " + newIconName);


    // PUT IN SPRITE SWITCHING CODE
    // How do I refer to my current sprite?
    

    // How do I request/load a new one by name?
    if (_atlas)
    {
      Sprite newSprite = _atlas.GetSprite(newIconName);

      _renderer.sprite = newSprite;
    }

  }
}
