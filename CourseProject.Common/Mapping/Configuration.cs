using AutoMapper;
using CourseProject.Common.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CourseProject.Common.Mapping
{
    public static class Configuration
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            var assembly = CommonSettings.Default.MapperProfilesAssembly;

            var profiles = GetProfilesFromAssembly(assembly);

            return new MapperConfiguration(cfg => {
                cfg.AddProfiles(profiles);
            });
        }

        private static IEnumerable<Type> GetProfilesFromAssembly(string assembly)
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => 
                    type.Namespace == assembly && 
                    Activator.CreateInstance(type) is Profile
                );
        }
    }
}
