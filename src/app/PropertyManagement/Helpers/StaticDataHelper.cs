using System.Collections.Generic;
using data.models.POCO;

namespace PropertyManagement.Helpers
{
    public static class StaticDataHelper
    {
        public static List<Province> GetCanadianProvinces()
        {
            return new List<Province>() {
                new Province {Abbreviation="AB", Name="Alberta"},
                new Province {Abbreviation="BC", Name="British Columbia"},
                new Province {Abbreviation="MB", Name="Manitoba"},
                new Province {Abbreviation="NB", Name="New Brunswick"},
                new Province {Abbreviation="NL", Name="Newfoundland and Labrador"},
                new Province {Abbreviation="NT", Name="Northwest Territories"},
                new Province {Abbreviation="NS", Name="Nova Scotia"},
                new Province {Abbreviation="NU", Name="Nunavut"},
                new Province {Abbreviation="ON", Name="Ontario"},
                new Province {Abbreviation="PE", Name="Prince Edward Island"},
                new Province {Abbreviation="QC", Name="Québec"},
                new Province {Abbreviation="SK", Name="Saskatchewan"},
                new Province {Abbreviation="YT", Name="Yukon Territory"},
            };
        }
    }
}