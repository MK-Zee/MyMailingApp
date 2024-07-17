using Volo.Abp.Modularity;

namespace FEProject;

/* Inherit from this class for your domain layer tests. */
public abstract class FEProjectDomainTestBase<TStartupModule> : FEProjectTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
