using System;
using UnityEngine;

public class AkBankLoader : MonoBehaviour
{
    public static AkBankLoader akBankLoaderInstance;

    public void Awake()
    {
        akBankLoaderInstance = this;
    }

    public void LoadSoundBanks()
    {
        AkUnitySoundEngine.LoadBank("Init", out _);
        AkUnitySoundEngine.LoadBank("SFX", out _);
        AkUnitySoundEngine.LoadBank("BGMusic", out _);
    }
}
