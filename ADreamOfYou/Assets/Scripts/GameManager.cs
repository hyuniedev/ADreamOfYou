using Enum;
using UnityEngine;
public class GameManager : MonoBehaviour
{ 
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<GameManager>();
            }
            return _instance;
        }
    }
    public bool IsFullscreen { get; set; }
    public ELanguage Language { get; set; } = ELanguage.English;
    public Resolution Resolution { get; private set; }
    public Volume Volume { get; set; } = new Volume(10, 10);
}

public struct Resolution
{
    public int Width;
    public int Height;

    public void SetResolution(bool isFullscreen)
    {
        Screen.SetResolution(Width, Height, isFullscreen);
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