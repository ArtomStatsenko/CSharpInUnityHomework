using System;
using UnityEngine;


public class CaughtPlayerEventArgs : EventArgs
{
    public Color Color { get; }

    public CaughtPlayerEventArgs(Color color)
    {
        Color = color;
    }
}
