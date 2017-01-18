using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using surplus_auctioneer_models;

namespace surplus_auctioneer_webapp.Models
{
    public class SearchViewModel : ViewModel
    {
        public SearchViewModel()
        {
            MinPrice = 0;
            MaxPrice = 1000;

            AuctionItems = new List<AuctionItem>();
        }

        [RegularExpression("([0-9]+)", ErrorMessage =  "Max Price must be a positive number")]
        public double MaxPrice { get; set; }

        [Range(0, 1000000.00,
            ErrorMessage = "Min Price must be between 0.01 and 1,000,000")]
        public double MinPrice { get; set; }

        [DisplayName("Keywords (comma delimited)")]
        [DataType(DataType.MultilineText)]
        public string Keywords { get; set; }

        [DisplayName("Auction Source")]
        public MultiSelectList AuctionSources { get; set; }

        public List<string> SelectedAuctionSources { get; set; }

        public List<AuctionItem> AuctionItems { get; set; }
    }
}