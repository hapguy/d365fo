using ODataClient.Microsoft.Dynamics.DataEntities;
using System;

namespace DataPackageHandler
{
    using AuthorizationHelper;
    using Microsoft.OData.Client;

    class Program
    {
        static void Main(string[] args)
        {
            string ODataEntityPath = AuthorizationHelper.aadResource + "/data";
            //string ODataEntityPath = AuthorizationHelper.aadResource + "/data/DANBPCTBExportTables?$filter=RefRecId eq 5638623938";
            Uri oDataUri = new Uri(ODataEntityPath, UriKind.Absolute);

            var d365Client = new Resources(oDataUri);
            d365Client.DANBPCTBExportTables.AddQueryOption("$filter", "RefRecId eq 5638623938");
            d365Client.SendingRequest2 += new EventHandler<SendingRequest2EventArgs>(delegate (object sender, SendingRequest2EventArgs e)
            {
                var authenticationHeader = AuthorizationHelper.GetAuthenticationHeader();
                e.RequestMessage.SetHeader("Authorization", authenticationHeader);
            });

            //PackageImporter.ImportPackage(d365Client, @"..\debug\SampleData\usmf_asset-major-types-01.zip");
            PackageExporter.ExportPackage(d365Client, @"SampleData\");

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }        
    }
}
