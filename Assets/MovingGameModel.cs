using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.U2D;
using Newtonsoft.Json;
using System.IO;

public class MovingGameModel : MonoBehaviour
{
  public static event Action<Dictionary<string, float>> OnPositionsUpdated = delegate { };
  public static event Action<string> OnIconUpdate = delegate { };

  protected Dictionary<string, float> _iconsY;

  protected float _distanceToMove = 0.25f; // How far to move each time

  private string _savePath = "";
  
  private void Awake()
  {
    // Fill our dictionary with some icon names and y positions.
    _iconsY = new Dictionary<string, float>() { {"tick", 0.5f },
                                                     {"spanner", 3.0f },
                                                     {"key", 1.0f },
                                                     {"star", 0.0f }};

    // set up path
    _savePath = Path.Combine(Application.persistentDataPath, "iconsY_save.json"); 
  }

  void Start()
  {
    OnPositionsUpdated(_iconsY);

    RequestMoveEventOnClick.OnMoveRequested += MoveRequestedHandler;
    RequestIconSwitch.OnIconSwitchRequested += SwitchRequestedHandler;
    //LoadStateAndAnnounce();
  }

  private void SavePositions()
  {
    // Serialize our objects to a JSon file
    string posJson = JsonConvert.SerializeObject(_iconsY);
    //Debug.Log("posJson: " + posJson);

    //string yPosJson = JsonConvert.SerializeObject(_iconsY);
    //JsonConvert.SerializeObject(_currIcon);
    File.WriteAllText(_savePath, posJson);
  }

private void Load()
  {
    // Don't try to load a file that isn't there
    if (File.Exists(_savePath))
    {
      string loadedJson = File.ReadAllText(_savePath);

      Dictionary<string, float> savedPosY = JsonConvert.DeserializeObject<Dictionary<string, float>>(loadedJson);
      //charState[HAT] = charSaved[HAT];
      Debug.Log(loadedJson);
      
      //OnIconUpdate(_iconNames[_currIcon]);
      //OnPositionsUpdated(_iconsY);
    }
    
  }

  private void SwitchRequestedHandler()
  {
    OnIconUpdate("cog");

  }

  private void MoveRequestedHandler( string direction )
  {
 
    float moveDistance = _distanceToMove;
    // Make that copy negative if direction == "down" 
    if (direction == "down") moveDistance *= -1;

    // This trick lets us loop through a dictionary. Requires `using System.Linq` at file start
    foreach (string key in _iconsY.Keys.ToList<string>())
    {
      // the key for each item in dictionary is used to access it and add the move distance
      _iconsY[key] += moveDistance;
    }

    // Announce updated positions for all icons.
    OnPositionsUpdated(_iconsY);
    SavePositions();
  }

}
