using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using TestXamarinApp.Exceptions;
using TestXamarinApp.OffersFromXmlParser.Resources;

namespace TestXamarinApp.OffersFromXmlParser
{
    public static class OffersFromXmlParser
    {
        private const string ElementsPath = "//offer";

        private static readonly OffersElementBuilder Builder = new OffersElementBuilder();
        
        
        public static async Task<OffersElement> ParseForOffer()
        {
            try
            {
                var xml = await XmlFromUrl.Get();

                var offers = GetOffersFromXml(xml);
            
                AddOffersBuilderInformation(offers);
            }
            catch
            {
                throw new GetXmlException();
            }

            
            return Builder.Build();
        }

        private static void AddOffersBuilderInformation(XmlNodeList offers)
        {
            foreach (XmlNode offer in offers)
            {
                if (AttributesChecking(offer)) continue;
                var elementId = GetOfferId(offer);
                var childrenElementInfo = AddOfferChildrenElementInfo(offer);
                Builder.Add(elementId, childrenElementInfo);
            }
        }

        private static bool AttributesChecking(XmlNode offer)
        {
            return offer.Attributes == null;
        }
        private static string GetOfferId(XmlNode offer)
        {
            return offer.Attributes?["id"].Value;
        }
        
        private static OfferChildrenElementInfo AddOfferChildrenElementInfo(XmlNode offer)
        {
            var childrenElementInfo = new OfferChildrenElementInfo();
            foreach (XmlNode child in offer.ChildNodes)
            {
                var name = child.Name;
                var value = child.InnerText;
                AddChildrenElementInfo(name, value, childrenElementInfo);
            }

            return childrenElementInfo;
        }

        private static bool NameExistence(string name, OfferChildrenElementInfo childrenElementInfo)
        {
            return childrenElementInfo.ChildElements.ContainsKey(name);
        }
        private static XmlNodeList GetOffersFromXml(XmlDocument xml)
        {
            var offers = xml.SelectNodes(ElementsPath);
            if (offers == null) throw new GetOffersException();
            return offers;
        }

        private static void AddChildrenElementInfo(string name, string value, OfferChildrenElementInfo childrenElementInfo)
        {
            if (value != null && !NameExistence(name, childrenElementInfo))
            {
                var valueList = new List<string> {value};
                childrenElementInfo
                    .ChildElements
                    .Add(name, valueList);
            }
            else if (NameExistence(name, childrenElementInfo))
            {
                childrenElementInfo
                    .ChildElements[name]
                    .Add(value);
            }
        }
    }
}