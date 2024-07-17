using FEProject.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FEProject.Permissions;

public class FEProjectPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(FEProjectPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(FEProjectPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<FEProjectResource>(name);
    }
}
