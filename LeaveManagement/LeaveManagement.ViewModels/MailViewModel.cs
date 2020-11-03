using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.ViewModels
{
    public class MailViewModel
    {
        [Required]
        public string FromEmail { get; set; }
        [Required]
        public string ToEmail { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }

    }
}
