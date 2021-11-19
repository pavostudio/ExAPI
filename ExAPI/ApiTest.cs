using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        TextBubbleEntity entity = new TextBubbleEntity();
        entity.id = 0;
        entity.text = "Test";
        entity.choices = new string[] { "Choice 1", "Choice 2" };

        RemoteMessage.Send(Msg.ShowTextBubble, 1, entity);
    }

    public static void SetModel()
    {
        ModelEntity entity = new ModelEntity();
        entity.id = 1;
        entity.file = "E:\\Projects\\Live2D\\Resources\\Live2DResource\\Models\\Sample2\\wanko\\wanko.model.json";
        RemoteMessage.Send(Msg.SetModel, 2, entity);
    }

    public static void SetBackground()
    {
        var entity = new BGEntity()
        {
            id = 1,
            file = "http://bing.com"
        };

        //string str = "D:\\Wallpaper\\Slideshow\\wallpaper.jpg";
        RemoteMessage.Send(Msg.SetBackgroundV2, 3, entity);
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

        RemoteMessage.Send(Msg.StartMotion, 4, entity);
    }

    public static void SetPosition()
    {
        ModelEntity entity = new ModelEntity();
        entity.id = 0;
        entity.posX = 0;
        entity.posY = 100;

        RemoteMessage.Send(Msg.SetPosition, 5, entity);
    }

    public static void SetExpression()
    {
        ModelEntity entity = new ModelEntity();
        entity.id = 0;
        entity.expId = 1;

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