namespace Practice;

public class StringProcessorConfig
{
    public string RandomApi { get; set; }
    public string[] BlackList { get; set; }
    public int ParallelLimit { get; set; }
    public bool CanConnect => ParallelLimit > CurrentConnections;

    private int CurrentConnections { get; set; }
    private readonly Semaphore _connectionSemaphore = new Semaphore(1, 1);

    public bool SetConnect()
    {
        _connectionSemaphore.WaitOne();
        
        var canConnect = CanConnect;
        if (canConnect)
            CurrentConnections++;
        
        _connectionSemaphore.Release();
        return canConnect;
    }

    public void CloseConnect()
    {
        CurrentConnections--;
    }
}