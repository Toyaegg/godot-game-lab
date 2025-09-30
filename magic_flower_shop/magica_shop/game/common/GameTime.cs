namespace MagicaShop.Game.Common;

using Godot;
using System;

public struct GameTime
{
    public int Year { get; }
    public int Month { get; }
    public int Day { get; }
    public int Hour { get; }
    public int Minute { get; }
    public int Tick { get; }

    public GameTime(int year, int month, int day, int hour, int minute, int tick)
    {
        Year = year;
        Month = month;
        Day = day;
        Hour = hour;
        Minute = minute;
        Tick = tick;
    }

    // 重写ToString方法，以便可以轻松打印时间
    public override string ToString()
    {
        return $"Year: {Year}, Month: {Month}, Day: {Day}, " +
               $"Hour: {Hour}, Tick: {Tick} (Minute: {Minute})";
    }
}