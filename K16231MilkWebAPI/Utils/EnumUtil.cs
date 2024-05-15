using System.ComponentModel;

namespace K16231MilkWebAPI.Utils
{
    public static class EnumUtil
    {
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static string GetEnumDescription<T>(this T value)
        {
            if(value == null) return string.Empty;

            var field = value?.GetType().GetField(value.ToString());
            if(field != null)
            {
                var attribute = (DescriptionAttribute[]) field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if(attribute.Length > 0)
                {
                    return attribute[0].Description;
                }
            }

            return value.ToString();
        }

        public static IEnumerable<T> GetValue<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
