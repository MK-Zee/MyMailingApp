using FEProject.Samples;
using Xunit;

namespace FEProject.EntityFrameworkCore.Domains;

[Collection(FEProjectTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<FEProjectEntityFrameworkCoreTestModule>
{

}
