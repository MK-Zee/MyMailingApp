using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace FEProject.Data;

/* This is used if database provider does't define
 * IFEProjectDbSchemaMigrator implementation.
 */
public class NullFEProjectDbSchemaMigrator : IFEProjectDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
