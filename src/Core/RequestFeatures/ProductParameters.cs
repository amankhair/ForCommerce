using System;

namespace Core.RequestFeatures
{
    public class ProductParameters : RequestParameters
    {
        public Guid? BrandId { get; set; }
        public Guid? CategoryId { get; set; }
        public string Sort { get; set; }

        private string _search;

        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}