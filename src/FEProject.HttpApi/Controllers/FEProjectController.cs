using FEProject.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FEProject.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class FEProjectController : AbpControllerBase
{
    protected FEProjectController()
    {
        LocalizationResource = typeof(FEProjectResource);
    }
}
