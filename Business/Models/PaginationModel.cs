using System.Globalization;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Business.Models
{
    public class PaginationModel
    {
        public int Page { get; set; } = 1;

        public int Take { get; set; } = 10;

        public int GetSkip() => (Page - 1) * Take;
    }
}
