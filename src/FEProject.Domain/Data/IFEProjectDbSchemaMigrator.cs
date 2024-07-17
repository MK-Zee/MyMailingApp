using System.Threading.Tasks;

namespace FEProject.Data;

public interface IFEProjectDbSchemaMigrator
{
    Task MigrateAsync();
}
