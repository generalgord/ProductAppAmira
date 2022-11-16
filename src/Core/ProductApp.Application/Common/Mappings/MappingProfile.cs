using AutoMapper;

using System.Reflection;

namespace ProductApp.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingProfilesFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingProfilesFromAssembly(Assembly assembly)
        {
            var mapFromType = typeof(IMapFrom<>);
            var mappingMethodName = nameof(IMapFrom<object>.Mapping);

            bool HasInterface(Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == mapFromType;

            var types_1 = assembly.GetExportedTypes().ToList();
            var types = assembly.GetExportedTypes().Where(w => w.GetInterfaces().Any(HasInterface)).ToList();

            var argumentTypes = new Type[] { typeof(Profile) };
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod(mappingMethodName);
                if (methodInfo != null)
                    methodInfo.Invoke(instance, new object[] { this });
                else
                {
                    var interfaces = type.GetInterfaces().Where(HasInterface).ToList();
                    if (interfaces.Count > 0)
                    {
                        foreach (var @interface in interfaces)
                        {
                            var interfaceMethodInfo = @interface.GetMethod(mappingMethodName, argumentTypes);
                            interfaceMethodInfo?.Invoke(instance, new object[] { this });
                        }
                    }
                }
            }
        }
    }
}
