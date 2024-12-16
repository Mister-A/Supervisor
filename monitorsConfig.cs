using System.Configuration;

namespace Supervisor
{
    /// <summary>
    /// Definition of monitor settings
    /// </summary>
    public class MonitorGroup : ConfigurationSection
    {
        public const string SectionName = "MonitorGroup";
        private const string MonitorCollectionName = "Applications";

        [ConfigurationProperty(MonitorCollectionName)]
        [ConfigurationCollection(typeof(MonitorCollection), AddItemName = "add", RemoveItemName = "remove")]
        public MonitorCollection Monitors { get { return (MonitorCollection)base[MonitorCollectionName]; } }

        public class MonitorCollection : ConfigurationElementCollection
        {
            protected override ConfigurationElement CreateNewElement()
            {
                return new ApplicationElement();
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((ApplicationElement)element).Name;
            }

            public void Add(ApplicationElement application)
            {
                BaseAdd(application);
            }

            protected override void BaseAdd(ConfigurationElement element)
            {
                BaseAdd(element, false);
            }

            public void Remove(ApplicationElement application)
            {
                if (BaseIndexOf(application) >= 0)
                {
                    BaseRemove(application.Name);
                }
            }

            public void RemoveAt(int index)
            {
                BaseRemoveAt(index);
            }

            public void Remove(string name)
            {
                BaseRemove(name);
            }

            public void Clear()
            {
                BaseClear();
            }
        }

        public class ApplicationElement : ConfigurationElement
        {
            [ConfigurationProperty("name", IsRequired = true)]
            public string Name
            {
                get { return (string)this["name"]; }
                set { this["name"] = value; }
            }

            [ConfigurationProperty("path", IsRequired = true)]
            public string Path
            {
                get { return (string)this["path"]; }
                set { this["path"] = value; }
            }

            [ConfigurationProperty("alert", IsRequired = true, DefaultValue = "0")]
            public string Alert
            {
                get { return (string)this["alert"]; }
                set { this["alert"] = value; }
            }

            [ConfigurationProperty("arguments", IsRequired = false, DefaultValue = "")]
            public string Arguments
            {
                get { return (string)this["arguments"]; }
                set { this["arguments"] = value; }
            }
        }
    }

    public class SettingsGroup : ConfigurationSection
    {
        public const string SectionName = "SettingsGroup";
        private const string SettingsCollectionName = "Settings";

        [ConfigurationProperty(SettingsCollectionName)]
        [ConfigurationCollection(typeof(SettingsCollection), AddItemName = "add", RemoveItemName = "remove")]
        public SettingsCollection Settings { get { return (SettingsCollection)base[SettingsCollectionName]; } }

        public class SettingsCollection : ConfigurationElementCollection
        {
            protected override ConfigurationElement CreateNewElement()
            {
                return new SettingsElement();
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((SettingsElement)element).Name;
            }

            public void Add(SettingsElement setting)
            {
                BaseAdd(setting);
            }

            protected override void BaseAdd(ConfigurationElement element)
            {
                BaseAdd(element, false);
            }

            public void Remove(SettingsElement setting)
            {
                if (BaseIndexOf(setting) >= 0)
                {
                    BaseRemove(setting.Name);
                }
            }

            public void RemoveAt(int index)
            {
                BaseRemoveAt(index);
            }

            public void Remove(string name)
            {
                BaseRemove(name);
            }

            public void Clear()
            {
                BaseClear();
            }
        }

        public class SettingsElement : ConfigurationElement
        {
            [ConfigurationProperty("name", IsRequired = true)]
            public string Name
            {
                get { return (string)this["name"]; }
                set { this["name"] = value; }
            }

            [ConfigurationProperty("value", IsRequired = true, DefaultValue = "")]
            public string Value
            {
                get { return (string)this["value"]; }
                set { this["value"] = value; }
            }
        }
    }
}