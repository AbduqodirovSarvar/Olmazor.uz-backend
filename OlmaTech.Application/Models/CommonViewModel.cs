using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.Models
{
    public class CommonViewModel
    {
        public List<HomePostViewModel>? Homes { get; set; }
        public AboutViewModel? About { get; set; }
        public List<ServiceViewModel>? Services { get; set; }
        public List<ProjectViewModel>? Projects { get; set; }
        public List<TeamViewModel>? Teams { get; set; }
        public List<ClientViewModel>? Clients { get; set; }
        public List<BlogPostViewModel>? Blogs { get; set; }
        public List<ContactViewModel>? Contacts { get; set; }
    }
}
