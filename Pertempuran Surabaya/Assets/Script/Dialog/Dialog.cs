using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[System.Serializable]
public class Dialog 
{
    public string name;
    [TextArea(3, 10)]
    public string[] sentences;
    public Sprite backGround;
    public Sprite karakter = null;
    public VideoClip video;
    
}
