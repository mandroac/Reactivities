using System.Collections.Generic;

namespace Domain.Models
{
    public static class ActivityCategories
    {
        public static readonly string Drinks = "drinks";
        public static readonly string Music = "music";
        public static readonly string Culture = "culture";
        public static readonly string Travel = "travel";
        public static readonly string Film = "film";
        public static readonly string Food = "food";


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