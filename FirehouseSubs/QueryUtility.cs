namespace FirehouseSubs
{
    internal class QueryUtility
    {
        internal static string FormatQueryParam(string key, object value)
        {
            return $"{key}={value}";
        }
    }
}
