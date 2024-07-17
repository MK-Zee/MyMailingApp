using System;
using System.Collections.Generic;
using System.Text;
using FEProject.Localization;
using Volo.Abp.Application.Services;

namespace FEProject;

/* Inherit your application services from this class.
 */
public abstract class FEProjectAppService : ApplicationService
{
    protected FEProjectAppService()
    {
        LocalizationResource = typeof(FEProjectResource);
    }
}
