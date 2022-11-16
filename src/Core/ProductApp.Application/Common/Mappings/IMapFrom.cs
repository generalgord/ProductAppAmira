using AutoMapper;

namespace ProductApp.Application.Common.Mappings
{
    public interface IMapFrom<T>
    {
        // Creates concrete map generic type
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
