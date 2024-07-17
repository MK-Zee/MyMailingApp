using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace FEProject.Pages;

public class Index_Tests : FEProjectWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
