using FEProject.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FEProject.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class FEProjectPageModel : AbpPageModel
{
    protected FEProjectPageModel()
    {
        LocalizationResourceType = typeof(FEProjectResource);
    }
}
