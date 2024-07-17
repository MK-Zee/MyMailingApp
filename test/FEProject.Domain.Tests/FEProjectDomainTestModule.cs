using Volo.Abp.Modularity;

namespace FEProject;

[DependsOn(
    typeof(FEProjectDomainModule),
    typeof(FEProjectTestBaseModule)
)]
public class FEProjectDomainTestModule : AbpModule
{

}
