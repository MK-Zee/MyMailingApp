using Volo.Abp.Modularity;

namespace FEProject;

public abstract class FEProjectApplicationTestBase<TStartupModule> : FEProjectTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
