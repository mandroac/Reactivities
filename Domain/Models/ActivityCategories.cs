using System.Collections.Generic;

namespace Domain.Models
{
    public static class ActivityCategories
    {
        public static readonly string Drinks = "Drinks";
        public static readonly string Music = "Music";
        public static readonly string Culture = "Culture";
        public static readonly string Travel = "Travel";
        public static readonly string Film = "Film";

        public static List<string> CategoriesList()
        {
            var members = typeof(ActivityCategories).GetFields();
            var list = new List<string>();

            foreach (var item in members)
            {
                list.Add(item.GetValue(item) as string);
            }

            return list;
        }
    }
}