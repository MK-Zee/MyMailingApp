using FEProject.Communities;
using FEProject.Emails;
using FEProject.Services;
using FEProject.Users;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace FEProject;

[DependsOn(
    typeof(FEProjectDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(FEProjectApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class FEProjectApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        context.Services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

        // Register email service
        context.Services.AddTransient<IEmailService, EmailService>();

        context.Services.AddTransient<IUserAppService, UserAppService>();
        context.Services.AddTransient<ICommunityAppService, CommunityAppService>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<FEProjectApplicationModule>();
        });
    }
}
