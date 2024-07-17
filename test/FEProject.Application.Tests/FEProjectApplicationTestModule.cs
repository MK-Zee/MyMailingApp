using Volo.Abp.Modularity;

namespace FEProject;

[DependsOn(
    typeof(FEProjectApplicationModule),
    typeof(FEProjectDomainTestModule)
)]
public class FEProjectApplicationTestModule : AbpModule
{

}
