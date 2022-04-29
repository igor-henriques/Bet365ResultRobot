namespace MainRobotOrchester.Interfaces;

/// <summary>
/// Interface que realiza contrato a ser seguido por todos os robôs.
/// Event = As tabs de horários que são criadas a cada 3 minutos, em média.
/// </summary>
public interface IWorker
{
    void StopDriver();
    Task DoWorkAsync(CancellationToken cancellationToken);
    Task ScrapAllEvents();
    Task ScrapEvent(IWebElement element, int index);
    Task SetLastEventValue();
    Task<bool> IsEventStarted(IWebElement _event, int index);
}