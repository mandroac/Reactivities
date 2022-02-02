using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace API.Extentions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, 
            int currentPage, int itemsPerPage, int totalItems, int totalPages)
            {
                var parinationHeader = new
                {
                    currentPage,
                    itemsPerPage,
                    totalItems,
                    totalPages
                };
                response.Headers.Add("Pagination", JsonSerializer.Serialize(parinationHeader));
                response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
            }
    }
}