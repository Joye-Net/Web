
namespace DomainServices
{
    public class TestService:ITestService
    {
        public string GetData()
        {
            return "这是插件获取的Services数据";
        }

        public string GetMainData()
        {
            return "这是主项目获取的Services数据";
        }
    }
}
