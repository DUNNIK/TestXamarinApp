using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestXamarinApp
{
    public static class XmlFromUrl
    {
        private const string Url = "https://yastatic.net/market-export/_/partner/help/YML.xml";
        
        public static async Task<XmlDocument> Get()
        {
            var resultData = new XmlDocument();
            await Task.Run(() =>
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                resultData.Load(Url);
            });
            return resultData;
        }
    }
}