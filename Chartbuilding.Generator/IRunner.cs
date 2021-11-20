using System.Threading.Tasks;

namespace Chartbuilding.Generator
{
    internal interface IRunner
    {
        ValueTask Generate();
    }
}
