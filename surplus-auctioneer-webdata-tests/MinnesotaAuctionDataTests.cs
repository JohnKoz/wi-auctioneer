using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using surplus_auctioneer_models;
using surplus_auctioneer_webdata;

namespace surplus_auctioneer_webdata_tests
{
    [TestClass]
    public class MinnesotaAuctionDataTests
    {
        [TestMethod]
        public void TestGetAllAuctionsForAnyResult()
        {
            ISurplusAuctionData mnSurplusAuctionData = new MinnesotaAuctionData();

            IEnumerable<Auction> auctions = mnSurplusAuctionData.GetAllAuctions(false, false, null);

            Assert.IsTrue(auctions.Any());
        }
    }
}
