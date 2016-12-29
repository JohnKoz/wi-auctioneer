using System.Collections.Generic;
using System.ComponentModel;
using surplus_auctioneer_models;

namespace surplus_auctioneer_webdata
{
    public interface ISurplusAuctionData
    {
        IEnumerable<Auction> GetAllAuctions(bool includeImages, bool includeEnded, BackgroundWorker bw);
        IEnumerable<AuctionItem> GetAuctionItemsByName(Auction auction, bool includeImages);
    }
}