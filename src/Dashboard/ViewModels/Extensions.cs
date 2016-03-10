namespace Dashboard.ViewModels
{
    public static class Extensions
    {
        public static string TrimForDisplay(this string input, int maxLength)
        {
            if(input.Length > maxLength)
            {
                return input.Substring(0, maxLength - 3) + "...";
            }

            return input;
        }
    }
}
