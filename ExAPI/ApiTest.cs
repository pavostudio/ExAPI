using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PavoStudio.ExApi;

class ApiTest
{
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

        //string str = "D:\\Wallpaper\\Slideshow\\yande.re 424111 landscape niko_p signed wallpaper.jpg";
        RemoteMessage.Send(Msg.SetBackground, str);
    }

    public static void RemoveModel()
    {
        RemoteMessage.Send(Msg.RemoveModel, 1);
    }

    public static void SetEffect()
    {
        Console.WriteLine("SetEffect: " + 100100);
        RemoteMessage.Send(Msg.SetEffect, 100100);
    }

    public static void AddEffect()
    {
        Console.WriteLine("AddEffect: " + 100100);
        RemoteMessage.Send(Msg.AddEffect, 100100);
    }

    public static void RemoveEffect()
    {
        Console.WriteLine("RemoveEffect: " + 100100);
        RemoteMessage.Send(Msg.RemoveEffect, 100100);
    }
}