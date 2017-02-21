using System;
using Umbraco.Core.Models;

namespace Umbraco.Web.PublishedContentModels
{
    public interface IArticleTags : IPublishedContent 
    {
        object Tags { get; }
    }
}
