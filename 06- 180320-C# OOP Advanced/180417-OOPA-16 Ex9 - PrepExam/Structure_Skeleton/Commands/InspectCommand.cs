using System.Collections.Generic;
using System.Linq;

public class InspectCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public InspectCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        int id = int.Parse(this.Arguments[0]);
        IEntity entity = this.harvesterController.Entities.FirstOrDefault(h => h.ID == id);

        if(entity == null)
            entity = this.providerController.Entities.FirstOrDefault(h => h.ID == id);

        if (entity == null)
            return string.Format(Constants.NoEntityFound, id);


        return entity.ToString();
    }
}

