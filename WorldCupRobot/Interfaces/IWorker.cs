namespace MainRobotOrchester.Interfaces;

/// <summary>
/// Interface que realiza contrato a ser seguido por todos os robôs.
/// Event = As tabs de horários que são criadas a cada 3 minutos, em média.
/// </summary>
public interface IWorker
{
    void StopDriver();
    Task DoWorkAsync();
    Task<bool> CheckEventTabAvailable();
    Task ScrapAllEvents();
    Task ScrapEvent(IWebElement element);
    Task ResolveData(Odd odd, string nomeTimeVisitante, string nomeTimeCasa, string eventSchedule);
    Task SetLastEventValue();
    Task<bool> IsEventStarted();
}