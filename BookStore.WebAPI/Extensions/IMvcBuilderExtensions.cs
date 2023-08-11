using BookStore.WebAPI.Utlities.Formatters;

namespace BookStore.WebAPI.Extensions
{
    public static class IMvcBuilderExtensions
    {
        public static IMvcBuilder AddCustonCvsFormatter(this IMvcBuilder builder) =>
            builder.AddMvcOptions(config =>
            config.OutputFormatters.Add(new CsvOutputFormatter()));
    }
}
