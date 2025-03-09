using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using PavoStudio.ExApi;

class ApiTest
{
    public static void RegisterModelEventListener()
    {
        RemoteMessage.Send(Msg.RegisterModelEventListener, 0);
    }

    public static void UnregisterModelEventListener()
    {
        RemoteMessage.Send(Msg.UnregisterModelEventListener, 0);
    }

    public static void ShowTextBubble()
    {
        var entity = new TextBubbleEntity()
        {
            id = 0,
            text = "Test",
            choices = new string[] { "Choice 1", "Choice 2" }
        };

        RemoteMessage.Send(Msg.ShowTextBubble, 1, entity);
    }

    public static void SetModel()
    {
        var entity = new ModelEntity()
        {
            id = 1,
            file = "E:\\Live2D\\wanko\\wanko.model.json"
        };
        RemoteMessage.Send(Msg.SetModel, 2, entity);
    }

    public static void SetBackground()
    {
        var entity = new BGEntity()
        {
            id = 1,
            file = "http://bing.com"
            // file="D:\\Wallpaper\\Slideshow\\wallpaper.jpg"
        };

        RemoteMessage.Send(Msg.SetBackgroundV2, 3, entity);
    }

    public static void RemoveModel()
    {
        RemoteMessage.Send(Msg.RemoveModel, 1);
    }

    public static void StartMotion(int type, string mtn)
    {
        var entity = new ModelEntity()
        {
            id = 0,
            type = type,
            mtn = mtn
        };

        RemoteMessage.Send(Msg.StartMotion, 4, entity);
    }

    public static void SetPosition()
    {
        var entity = new ModelEntity()
        {
            id = 0,
            posX = 0,
            posY = 100
        };

        RemoteMessage.Send(Msg.SetPosition, 5, entity);
    }

    public static void PlaySound()
    {
        var entity = new SoundEntity()
        {
            id = 0,
            channel = 0,
            type = 0,
            sound = "C:\\test.mp3"
        };

        RemoteMessage.Send(Msg.PlaySound, 7, entity);
    }
    public static void PlaySoundBinary()
    {
        var entity = new SoundEntity()
        {
            id = 0,
            channel = 0,
            type = 1
        };

        var bytes = File.ReadAllBytes("C:\\test.mp3");
        entity.sound = Convert.ToBase64String(bytes);

        RemoteMessage.Send(Msg.PlaySound, 7, entity);
    }

    public static void StopSound()
    {
        var entity = new SoundEntity()
        {
            id = 0,
            channel = 0
        };

        RemoteMessage.Send(Msg.StopSound, 8, entity);
    }

    public static void SetExpression()
    {
        ModelEntity entity = new ModelEntity()
        {
            id = 0,
            expId = 1
        };

        RemoteMessage.Send(Msg.SetExpression, 6, entity);
    }

    public static void NextExpression()
    {
        RemoteMessage.Send(Msg.NextExpression, 0);
    }

    public static void ClearExpression()
    {
        RemoteMessage.Send(Msg.ClearExpression, 0);
    }

    public static void SetEffect()
    {
        RemoteMessage.Send(Msg.SetEffect, 100100);
    }

    public static void AddEffect()
    {
        RemoteMessage.Send(Msg.AddEffect, 100100);
    }

    public static void RemoveEffect()
    {
        RemoteMessage.Send(Msg.RemoveEffect, 100100);
    }
}