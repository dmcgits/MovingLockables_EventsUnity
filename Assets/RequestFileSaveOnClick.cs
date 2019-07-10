using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RequestFileSaveOnClick : MonoBehaviour {

	public static event Action OnFileSaveRequested = delegate { };

  private void OnMouseUpAsButton()
  {
    OnFileSaveRequested();
  }
}
