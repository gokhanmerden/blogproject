using data.tables;
using services.Query;

namespace data_test;

public class UnitTest1
{
    [Fact]
    public async void Test1()
    {
        var kredilerQuery = new KredilerQuery();
        var datas =  await new KredilerQuery.Handler().Handle(kredilerQuery,CancellationToken.None);
        Assert.True( datas != null);
        
        Assert.Collection<Krediler>(datas,e =>
        {
            Assert.Contains(e.name,"İyi ki Tanışmışız, dedirten kredi");
        });
    }
}