public interface IMissionable
{
    string CodeName { get; }
    MissionState State { get; }
    void Complete();
}
