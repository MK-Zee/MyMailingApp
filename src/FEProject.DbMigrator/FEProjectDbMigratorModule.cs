using FEProject.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace FEProject.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(FEProjectEntityFrameworkCoreModule),
    typeof(FEProjectApplicationContractsModule)
    )]
public class FEProjectDbMigratorModule : AbpModule
{
}
