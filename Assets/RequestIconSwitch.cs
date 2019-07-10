using System;
using System.Collections.Generic;
using UnityEngine;

public class RequestIconSwitch : MonoBehaviour {

  public static event Action OnIconSwitchRequested = delegate { };

  private void OnMouseUpAsButton()
  {
    OnIconSwitchRequested();
  }
}
