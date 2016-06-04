//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v3.0.2.93
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder;
using Umbraco.ModelsBuilder.Umbraco;

namespace Umbraco.Web.PublishedContentModels
{
	/// <summary>Redirect Page</summary>
	[PublishedContentModel("redirectPage")]
	public partial class RedirectPage : PublishedContentModel, INavigationComponent, ITitleComponent
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "redirectPage";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public RedirectPage(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<RedirectPage, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// redirectUrl: Redirects to the url
		///</summary>
		[ImplementPropertyType("redirectUrl")]
		public string RedirectUrl
		{
			get { return this.GetPropertyValue<string>("redirectUrl"); }
		}

		///<summary>
		/// umbracoInternalRedirectId: Will load the selected page content transparently; no url redirection
		///</summary>
		[ImplementPropertyType("umbracoInternalRedirectId")]
		public object UmbracoInternalRedirectId
		{
			get { return this.GetPropertyValue("umbracoInternalRedirectId"); }
		}

		///<summary>
		/// umbracoRedirect: Redirects to the selected page
		///</summary>
		[ImplementPropertyType("umbracoRedirect")]
		public object UmbracoRedirect
		{
			get { return this.GetPropertyValue("umbracoRedirect"); }
		}

		///<summary>
		/// #PropertyHideInNavigation: #PropertyHideInNavigationDesc
		///</summary>
		[ImplementPropertyType("umbracoNaviHide")]
		public bool UmbracoNaviHide
		{
			get { return NavigationComponent.GetUmbracoNaviHide(this); }
		}

		///<summary>
		/// #PropertyTitle: #PropertyTitleDesc
		///</summary>
		[ImplementPropertyType("title")]
		public string Title
		{
			get { return TitleComponent.GetTitle(this); }
		}
	}
}
