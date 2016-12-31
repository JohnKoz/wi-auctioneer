using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using surplus_auctioneer_models;
using surplus_auctioneer_webdata;

namespace surplus_auctioneer_webdata_tests
{
    [TestClass]
    public class IllinoisAuctionDataTests
    {
        [TestMethod]
        public void TestGetAllAuctions()
        {
            ISurplusAuctionData illinoisAuctionData = new IllinoisAuctionData();

            IEnumerable<Auction> auctions = illinoisAuctionData.GetAllAuctions(false, false, null);

            Assert.IsTrue(auctions.Any());
        }
    }
}
