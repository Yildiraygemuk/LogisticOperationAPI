using Microsoft.Extensions.Configuration;

namespace LogisticCompany.Helper.AppSetting
{
    public static class AppSettings
    {
        private static IConfiguration _configuration;

        private static IConfiguration Configuration => _configuration ??= new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();


        public static string SecurityKey => Configuration.GetSection("TokenOptions:SecurityKey").Value;
    }
}