namespace MainRobotOrchester.Utils;

internal static class Converters
{
    public static TimeSpan ToTimeSpan(this string delayTime)
    {
        if (string.IsNullOrEmpty(delayTime?.Trim())) return TimeSpan.Zero;

        delayTime = delayTime.Trim().Replace("Encerrará", string.Empty);

        var delayTimeArray = delayTime.Split(':');

        int.TryParse(delayTimeArray[0], out int minutes);
        int.TryParse(delayTimeArray[0], out int seconds);

        TimeSpan delay = TimeSpan.FromMinutes(minutes).Add(TimeSpan.FromSeconds(seconds));

        return delay;
    }
}