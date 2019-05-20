using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToggleController : MonoBehaviour
{
    public GameObject FPSCamera;
    public GameObject NoClipCamera;

    public void Start(){
      NoClipCamera.SetActive(false);
      FPSCamera.SetActive(true);
    }

    public void Update(){
      if (Input.GetKeyDown(KeyCode.Alpha1)){
        NoClipCamera.SetActive(false);
        FPSCamera.SetActive(true);
      }
      if (Input.GetKeyDown(KeyCode.Alpha2)){
        FPSCamera.SetActive(false);
        NoClipCamera.SetActive(true);
      }
    }
}
