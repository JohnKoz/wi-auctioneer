using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace surplus_auctioneer_webapp.Models
{
    public abstract class ViewModel
    {
        private string _errorMessage;
        private bool _hasError;

        public virtual string ErrorMessage
        {
            get { return string.IsNullOrEmpty(_errorMessage) ? "An error has occured" : _errorMessage; }
            set
            {
                _errorMessage = value;
                _hasError = true;
            }
        }

        public virtual bool HasError
        {
            get { return _hasError; }
            set { _hasError = value; }
        }
    }
}