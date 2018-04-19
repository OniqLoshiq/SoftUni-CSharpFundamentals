using System;
using System.Linq;

public class GameController
{
    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController missionController;
    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;
    private IWriter writer;

    public GameController(IWriter writer)
    {
        this.army = new Army();
        this.wareHouse = new WareHouse();
        this.missionController = new MissionController(this.army, this.wareHouse);
        this.soldierFactory = new SoldierFactory();
        this.missionFactory = new MissionFactory();
        this.writer = writer;
    }

    public void GiveInputToGameController(string input)
    {
        var data = input.Split();

        if (data[0].Equals("Soldier"))
        {
            string type = string.Empty;
            string name = string.Empty;
            int age = 0;
            double experience = 0d;
            double endurance = 0d;

            if (data.Length == 3)
            {
                this.army.RegenerateTeam(data[2]);
            }
            else
            {
                type = data[1];
                name = data[2];
                age = int.Parse(data[3]);
                experience = double.Parse(data[4]);
                endurance = double.Parse(data[5]);

                ISoldier soldier = this.soldierFactory.CreateSoldier(type, name, age, experience, endurance);

                if(this.wareHouse.TryAddSoldier(soldier))
                {
                    this.army.AddSoldier(soldier);
                }
                else
                {
                    throw new ArgumentException(string.Format(OutputMessages.SoldierCannotBeEquiped, type, name));
                }
            }
        }
        else if (data[0].Equals("WareHouse"))
        {
            string name = data[1];
            int number = int.Parse(data[2]);

            this.wareHouse.AddWeapon(name, number);
        }
        else if (data[0].Equals("Mission"))
        {
            IMission mission = this.missionFactory.CreateMission(data[1], double.Parse(data[2]));
            this.writer.AppendLine(this.missionController.PerformMission(mission).Trim());
        }
    }

    public void RequestResult()
    {
        this.missionController.FailMissionsOnHold();
        this.writer.AppendLine(OutputMessages.Results);
        this.writer.AppendLine(string.Format(OutputMessages.SuccessfullMissionsCount, this.missionController.SuccessMissionCounter));
        this.writer.AppendLine(string.Format(OutputMessages.FailedMissionsCount, this.missionController.FailedMissionCounter));
        this.writer.AppendLine(OutputMessages.Soldiers);
        foreach (var soldier in this.army.Soldiers.OrderByDescending(s => s.OverallSkill))
        {
            this.writer.AppendLine(soldier.ToString());
        }
    }
}
