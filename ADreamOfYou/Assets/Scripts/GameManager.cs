using DesignPattern;
using Enum;
using UnityEngine;
public class GameManager : Singleton<GameManager>
{ 
    public bool IsFullscreen { get; set; } = true;
    public ELanguage Language { get; set; } = ELanguage.English;
    public Resolution Resolution { get; set; } = new Resolution(1920, 1080);
    public Volume Volume { get; set; } = new Volume(10, 10);

    public void ApplyResolution()
    {
        this.Resolution.SetResolution(IsFullscreen);
    }
}

public struct Resolution
{
    public int Width;
    public int Height;

    public Resolution(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    public void SetResolution(bool isFullscreen)
    {
        Screen.SetResolution(Width, Height, isFullscreen);
    }

    public override string ToString()
    {
        return this.Width + "x" + this.Height;
    }
}

public struct Volume
{
    public int Music;
    public int Sound;

    public Volume(int music, int sound)
    {
        Music = music;
        Sound = sound;
    }
}