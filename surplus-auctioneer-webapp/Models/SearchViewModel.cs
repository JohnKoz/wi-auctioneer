using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using surplus_auctioneer_models;

namespace surplus_auctioneer_webapp.Models
{
    public class SearchViewModel
    {
        public SearchViewModel()
        {
            MinPrice = 0;
            MaxPrice = 1000;
        }

        [RegularExpression("([0-9]+)", ErrorMessage =  "Max Price must be a positive number")]
        public double MaxPrice { get; set; }

        [Range(0, 1000000.00,
            ErrorMessage = "Min Price must be between 0.01 and 1,000,000")]
        public double MinPrice { get; set; }

        [DataType(DataType.MultilineText)]
        public string Keywords { get; set; }

        public List<AuctionItem> AuctionItems { get; set; }

        public string ErrorMessage { get; set; }
    }
}