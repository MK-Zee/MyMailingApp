using Xunit;

namespace FEProject.EntityFrameworkCore;

[CollectionDefinition(FEProjectTestConsts.CollectionDefinitionName)]
public class FEProjectEntityFrameworkCoreCollection : ICollectionFixture<FEProjectEntityFrameworkCoreFixture>
{

}
