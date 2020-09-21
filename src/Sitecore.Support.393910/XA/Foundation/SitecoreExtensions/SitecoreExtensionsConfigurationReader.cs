using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.XA.Foundation.SitecoreExtensions;
using System.Linq;
using System.Xml;

namespace Sitecore.Support.XA.Foundation.SitecoreExtensions
{
    public class SitecoreExtensionsConfigurationReader: Sitecore.XA.Foundation.SitecoreExtensions.SitecoreExtensionsConfigurationReader
    {
        protected override SitecoreExtensionsConfiguration ReadConfiguration()
        {
            return new SitecoreExtensionsConfiguration
            {
                MaxToolbarCommands = Settings.GetIntSetting("XA.Foundation.SitecoreExtensions.MaxToolbarCommands", 7),
                ParentOfTemplateCacheMaxSize = StringUtil.ParseSizeString(Settings.GetSetting("XA.Foundation.SitecoreExtensions.ParentOfTemplateCacheMaxSize", "50MB")),
                ChildOfTemplateCacheMaxSize = StringUtil.ParseSizeString(Settings.GetSetting("XA.Foundation.SitecoreExtensions.ChildOfTemplateCacheMaxSize", "50MB")),
                TemplateInheritanceCacheMaxSize = StringUtil.ParseSizeString(Settings.GetSetting("XA.Foundation.SitecoreExtensions.TemplateInheritanceCacheMaxSize", "50MB")),
                ExtendedPropertiesCacheMaxSize = StringUtil.ParseSizeString(Settings.GetSetting("XA.Foundation.SitecoreExtensions.ExtendedPropertiesCacheMaxSize", "50MB")),
                HiddenContentEditorFields = GetFieldsToHide(),
                AllowedFileNames = Factory.GetConfigNodes("experienceAccelerator/sitecoreExtensions/filterUrlFilesAndExtensions/file").Cast<XmlNode>().Select(node => node.InnerText).ToList(),
                DependentModules = GetDependentModules(),
                ChildrenGroupingTemplateIds = Factory.GetStringSet("experienceAccelerator/sitecoreExtensions/childrenGroupingTemplates/template").Where(ID.IsID).Select(id => new ID(id)).ToList()
            };
        }
    }
}