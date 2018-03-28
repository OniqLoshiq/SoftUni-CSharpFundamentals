using Logger.Model.Models;

namespace Logger.Model.Interfaces
{
    public interface ILayout
    {
        string GetLayoutOutput(ILog log);
    }
}
