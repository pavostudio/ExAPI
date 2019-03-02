using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PavoStudio.ExApi;

class ApiTest
{
    public static void RegisterModelEventListener()
    {
        RemoteMessage.Send(Msg.RegisterModelEventListener);
    }

    public static void UnregisterModelEventListener()
    {
        RemoteMessage.Send(Msg.UnregisterModelEventListener);
    }

    public static void SetModel()
    {
        ModelEntity entity = new ModelEntity();
        entity.id = 1;
        entity.file = "E:\\Projects\\Live2D\\Resources\\Live2DResource\\Models\\Sample2\\wanko\\wanko.model.json";
        RemoteMessage.Send(Msg.SetModel, entity);
    }

    public static void SetBackground()
    {
        string str = "http://bing.com";

        //string str = "D:\\Wallpaper\\Slideshow\\wallpaper.jpg";
        RemoteMessage.Send(Msg.SetBackground, str);
    }

    public static void RemoveModel()
    {
        RemoteMessage.Send(Msg.RemoveModel, 1);
    }

    public static void StartMotion(int type, string mtn)
    {
        ModelEntity entity = new ModelEntity();
        entity.id = 0;
        entity.type = type;
        entity.mtn = mtn;

        RemoteMessage.Send(Msg.StartMotion, entity);
    }

    public static void SetPosition()
    {
        ModelEntity entity = new ModelEntity();
        entity.id = 0;
        entity.posX = 200;
        entity.posY = 200;

        RemoteMessage.Send(Msg.SetPosition, entity);
    }

    public static void SetExpression()
    {
        ModelEntity entity = new ModelEntity();
        entity.id = 0;
        entity.expId = 1;

        RemoteMessage.Send(Msg.SetExpression, entity);
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