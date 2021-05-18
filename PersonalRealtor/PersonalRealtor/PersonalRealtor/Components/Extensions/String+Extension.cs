using System;
namespace PersonalRealtor.Components.Extensions
{
    public static class String_Extension
    {
        public static string ToCapitalize(this string the_string)
        {
            if (the_string == null || the_string.Length < 2)
                return the_string;

            string[] words = the_string.Split(
                new char[] { },
                StringSplitOptions.RemoveEmptyEntries);

            string result = "";
            for (int i = 0; i < words.Length; i++)
            {
                if (result.Length == 0)
                {
                    result +=
                    words[i].Substring(0, 1).ToUpper() +
                    words[i].Substring(1);
                }
                else
                {
                    result += " " +
                    words[i].Substring(0, 1).ToUpper() +
                    words[i].Substring(1);
                }
                
            }

            return result;
        }
    }
}
