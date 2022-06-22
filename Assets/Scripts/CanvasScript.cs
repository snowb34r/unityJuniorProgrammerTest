using System;
using System.IO;
using UnityEngine;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class CanvasScript : MonoBehaviour
{
    public void ReadStringInput(string s)
    {
        MenuManager.Instance.ReadStringInput(s);
    }
    public void ChangeScenes(int sceneNum)
    {
        MenuManager.Instance.ChangeScenes(sceneNum);
    }
    public void Exit()
    {
        MenuManager.Instance.Exit();
    }
}
