using CommandQuery;
using System.ComponentModel.DataAnnotations;

namespace Recruitment.Contracts
{
    public class CalculateHashCommand : ICommand<string>
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}