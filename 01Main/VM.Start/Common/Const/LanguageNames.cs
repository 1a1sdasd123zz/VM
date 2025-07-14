using System.Collections.Generic;
using System.Globalization;

namespace VM.Start.Common.Const
{
    public static class LanguageNames
    {
        public const string Chinese = "zh";
        public const string English = "en";
        public static List<CultureInfo> AvailableCultureInfos { get; } = new List<CultureInfo>
        {
            new CultureInfo("en"),
            new CultureInfo("zh"),
        };

    }
}
