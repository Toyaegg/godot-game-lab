using Godot;
using MagicaShop.Game.Common;
using QFramework;

namespace MagicaShop.Game.Systems;

public class TimeSystem : AbstractSystem
{
    // 定义时间单位
    private int year = 0, month = 1, day = 1; // 注意：月和日从1开始
    private int hour = 0, minute = 0, tick = 0; // 每小时8刻，每刻25分钟

    // 定义时间流速
    private float timeSpeed = 1.0f; // 正常速度为1.0

    // 定义一天、一个月、一年的时间长度（以分钟为单位）
    private const int MinutesPerTick = 25;
    private const int TicksPerHour = 8;
    private const int MinutesPerHour = MinutesPerTick * TicksPerHour;
    private const int HoursPerDay = 12;
    private const int DaysPerMonth = 30;
    private const int MonthsPerYear = 8;
    private const int DayssPerYear = 240;
    private const int MinutesPerDay = MinutesPerHour * HoursPerDay;
    private const int MinutesPerMonth = MinutesPerDay * DaysPerMonth;
    private const int MinutesPerYear = MinutesPerMonth * MonthsPerYear;
    
    protected override void OnInit()
    {
        
    }

    public void UpdateTime()
    {
        for (int i = 0; i < timeSpeed; i++)
        {
            AdvanceTime();
        }
    }

    private void AdvanceTime()
    {
        minute++;
        if (minute >= MinutesPerTick)
        {
            minute -= MinutesPerTick;
            tick++;
            if (tick >= TicksPerHour)
            {
                tick -= TicksPerHour;
                hour++;
                if (hour >= HoursPerDay)
                {
                    hour -= HoursPerDay;
                    day++;
                    if (day > DaysPerMonth)
                    {
                        day = 1;
                        month++;
                        if (month > MonthsPerYear)
                        {
                            month = 1;
                            year++;
                        }
                    }
                }
            }
        }
    }

    public void FastForward(int minutes)
    {
        for (int i = 0; i < minutes; i++)
        {
            AdvanceTime();
        }
    }

    public void FastForwardTo(int targetYear, int targetMonth, int targetDay, int targetHour, int targetMinute, int targetTick)
    {
        // 设置时间到指定值
        year = targetYear;
        month = targetMonth;
        day = targetDay;
        hour = targetHour;
        minute = targetMinute;
        tick = targetTick;
    }

    public void SetTimeSpeed(float speed)
    {
        timeSpeed = speed;
    }
    
    // 添加一个方法用于获取当前时间作为结构体
    public GameTime GetCurrentTime()
    {
        return new GameTime(year, month, day, hour, minute, tick);
    }
    
    public void PrintCurrentTime()
    {
        string currentTime = FormatCurrentTime();
        GD.Print(currentTime);
    }

    private string FormatCurrentTime()
    {
        return $"Year: {year}, Month: {month}, Day: {day}, " +
               $"Hour: {hour}, Tick: {tick} (Minute: {minute})";
    }
}