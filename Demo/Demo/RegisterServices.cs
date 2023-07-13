using Demo_Data;

namespace Demo
{
    public class RegisterServices
    {
        public static void Register(IServiceCollection services)
        {
            Configure(services, DataRegister.GetTypes());
        }

        public static void Configure(IServiceCollection services,Dictionary<Type,Type> types) {
           foreach (var item in types)
            {
                services.AddScoped(item.Key , item.Value);
            }
    
        }
    }
}
