using System;

public class Mission : IMissionable
{
    public string CodeName { get; private set; }
    public MissionState State { get; private set; }

    public Mission(string codeName, string state)
    {
        CodeName = codeName;
        ParseMissionState(state);
    }

    private void ParseMissionState(string state)
    {
        bool validState = Enum.TryParse(typeof(MissionState), state, out object thisState);
        if (validState)
            this.State = (MissionState)thisState;
        else
            throw new Exception();
    }

    public void Complete()
    {
        if(this.State == MissionState.Finished)
        {
            throw new InvalidOperationException("Mission already finished!");
        }
        this.State = MissionState.Finished;
    }

    public override string ToString()
    {
        return $"Code Name: {CodeName} State: {State.ToString()}";
    }
}
