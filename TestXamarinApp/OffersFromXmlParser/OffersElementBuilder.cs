

using TestXamarinApp.OffersFromXmlParser.Resources;

namespace TestXamarinApp.OffersFromXmlParser
{
    public class OffersElementBuilder
    {
        private readonly OffersInfo _offers;

        public OffersElementBuilder()
        {
            _offers = new OffersInfo();
        }

        public OffersElementBuilder Add(string id, 
            OfferChildrenElementInfo offerChildrenElementInfo)
        {
            _offers.ElementInfos.Add(id, offerChildrenElementInfo);
            return this;
        }
        
        public OffersElement Build() => new OffersElement(_offers);
    }
}