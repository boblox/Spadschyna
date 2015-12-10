using System.Collections.Generic;
using Umbraco.Core.Models;

namespace Logic.Models
{
    public class NewsResult : NewsPager
    {
        public NewsResult()
            : base()
        {
        }

        public List<IPublishedContent> News { get; set; }
    }
}
