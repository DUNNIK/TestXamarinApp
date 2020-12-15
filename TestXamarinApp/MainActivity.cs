using System;
using System.Text;
using Android.App;
using Android.Widget;
using Android.OS;
using Newtonsoft.Json;

namespace TestXamarinApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : ListActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            base.OnCreate(savedInstanceState);

            var offersElement = await OffersFromXmlParser.OffersFromXmlParser.ParseForOffer();

            var ids = offersElement.Ids();

            ListAdapter = new ArrayAdapter<string>
                (this, Android.Resource.Layout.SimpleListItem1, ids);

            ListView.TextFilterEnabled = true;

            ListView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                Toast.MakeText
                        (Application, JsonConvert.SerializeObject(offersElement.OfferInfo(((TextView)args.View).Text)), ToastLength.Short)
                    .Show();
            };


        }
    }
}