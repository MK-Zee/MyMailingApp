using FEProject.Samples;
using Xunit;

namespace FEProject.EntityFrameworkCore.Applications;

[Collection(FEProjectTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<FEProjectEntityFrameworkCoreTestModule>
{

}
