using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private const double HalfModePercentage = 0.5;
    private const double EnergyModePercentage = 0.2;

    private List<IHarvester> harvesters;
    private IHarvesterFactory harvesterFactory;
    private IEnergyRepository energyRepository;
    private string mode;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.harvesters = new List<IHarvester>();
        this.harvesterFactory = new HarvesterFactory();
        this.energyRepository = energyRepository;
        this.mode = Constants.DefaultMode;
    }

    public double OreProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public string ChangeMode(string mode)
    {
        this.mode = mode;

        List<IHarvester> reminder = new List<IHarvester>();

        foreach (var harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception)
            {
                reminder.Add(harvester);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        return string.Format(Constants.ModeChange, this.mode);
    }

    public string Produce()
    {
        double neededEnergy = 0;
        foreach (var harvester in this.harvesters)
        {
            if (this.mode == Constants.DefaultMode)
            {
                neededEnergy += harvester.EnergyRequirement;
            }
            else if (this.mode == Constants.HalfMode)
            {
                neededEnergy += harvester.EnergyRequirement * HalfModePercentage;
            }
            else if(this.mode == Constants.EnergyMode)
            {
                neededEnergy += harvester.EnergyRequirement * EnergyModePercentage;
            }
        }

        //check if we can mine
        double minedOres = 0;
        if (this.energyRepository.TakeEnergy(neededEnergy))
        {
            foreach (var harvester in this.harvesters)
            {
                minedOres += harvester.Produce();
            }
        }

        //take the mode in mind
        if (this.mode == Constants.EnergyMode)
        {
            minedOres *= EnergyModePercentage;
        }
        else if (this.mode == Constants.HalfMode)
        {
            minedOres *= HalfModePercentage;
        }

        this.OreProduced += minedOres;

        return string.Format(Constants.OreOutputToday, minedOres).Trim();
    }

    public string Register(IList<string> args)
    {
        IHarvester harvester = this.harvesterFactory.GenerateHarvester(args);
        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
    }
}
