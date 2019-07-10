using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RequestFileLoadOnClick : MonoBehaviour {

	public static event Action OnFileLoadRequested = delegate { };

  private void OnMouseUpAsButton()
  {
    OnFileLoadRequested();
  }
}
