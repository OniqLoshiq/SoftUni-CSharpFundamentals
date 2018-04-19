using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

public class MissionControllerTests
{
    [Test]
    public void MissionControllerDisplaysFailMessage()
    {
        var army = new Army();
        var wareHouse = new WareHouse();
        var missionController = new MissionController(army, wareHouse);

        var mission = new Easy(1);

        string result = string.Empty;
        for (int i = 0; i < 4; i++)
        {
            result = missionController.PerformMission(mission);
        }

        Assert.IsTrue(result.StartsWith("Mission declined"));
    }

    [Test]
    public void MissionControllerDisplaysSuccessMessage()
    {
        var army = new Army();
        var wareHouse = new WareHouse();
        var missionController = new MissionController(army, wareHouse);

        var mission = new Easy(0);

        string result = missionController.PerformMission(mission);
        

        Assert.IsTrue(result.StartsWith("Mission completed"));
    }
}
