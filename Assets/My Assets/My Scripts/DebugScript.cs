using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
  public class DebugScript : MonoBehaviour
  {
    public GameObject targetPoint;
    StateSaver savedState;

    void Awake()
    {
        savedState = (GameObject.FindWithTag("StateSaver")).GetComponent(typeof(StateSaver)) as StateSaver;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
      if (other.tag == "Player")
      {
        savedState.player.transform.SetPositionAndRotation(targetPoint.transform.position, targetPoint.transform.rotation);
        savedState.playerHandler.playerController.runSpeed = savedState.defaultRunningSpeed;
      }
    }
  }
}
