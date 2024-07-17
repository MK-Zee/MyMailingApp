using Microsoft.AspNetCore.Builder;
using FEProject;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<FEProjectWebTestModule>();

public partial class Program
{
}
