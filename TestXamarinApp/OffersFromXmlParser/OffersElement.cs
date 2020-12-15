using System.Collections.Generic;
using System.Linq;
using TestXamarinApp.OffersFromXmlParser.Resources;

namespace TestXamarinApp.OffersFromXmlParser
{
    public class OffersElement
    {
        private readonly OffersInfo _offers;

        public OffersElement(OffersInfo offers)
        {
            _offers = offers;
        }

        public List<string> Ids()
        {
            return _offers.ElementInfos.Keys.ToList();
        }

        public OfferChildrenElementInfo OfferInfo(string id)
        {
            return _offers.ElementInfos[id];
        }
    }
}