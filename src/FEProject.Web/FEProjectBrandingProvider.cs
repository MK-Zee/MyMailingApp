using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FEProject.Web;

[Dependency(ReplaceServices = true)]
public class FEProjectBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "FEProject";
}
