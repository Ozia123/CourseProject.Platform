using CourseProject.Common.ApplicationSettings;

namespace CourseProject.Common.Properties
{
    public class CommonSettings : ApplicationSettingsBase
    {
        public static CommonSettings Default
        {
            get
            {
                return new CommonSettings("common.appsettings.json");
            }
        }

        private CommonSettings(string jsonFile)
            : base(jsonFile)
        {
        }

        public string MapperProfilesAssembly
        {
            get
            {
                return sections["MapperProfilesAssembly"].Value;
            }
        }
    }
}
