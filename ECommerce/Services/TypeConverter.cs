namespace ECommerce.Services;

public static class TypeConverter
{
    public static TResult? Convert<TResult, T>(T model) where TResult: class, new()
    {
        var result = new TResult();
        var type = typeof(TResult);

        typeof(T).GetProperties().ToList().ForEach(p =>
        {
            var property = type.GetProperty(p.Name);

            try
            {
                property.SetValue(result, p.GetValue(model));
            }
            catch { }
        });

        return result;
    }
}
