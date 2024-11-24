using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{
    private static IAudioService audioService;
    public static void RegisterAudioService(IAudioService service)
    {
        audioService = service;
    }
    public static IAudioService GetAudioService()
    {
        if (audioService == null)
        {
            throw new Exception("Not AudioService");
        }
        return audioService;
    }
}