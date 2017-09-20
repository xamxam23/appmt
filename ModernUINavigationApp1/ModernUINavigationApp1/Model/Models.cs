using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUINavigationApp1.Model
{
    class CVInfo
    {
        public string name { get; set; }
        public int age { get; set; }
        public int rating { get; set; }
    }

    class SkillSet
    {
        public string name { get; set; }
        public int months { get; set; }
        public int rating { get; set; }
    }

    class WorkExperience
    {
        public string company { get; set; }
        public string position { get; set; }
        public int months { get; set; }
    }

    class Qualifications
    {
        public string title { get; set; }
        public string institution {get; set; }
        public int year { get; set; }
    }

    class References
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string company { get; set; }
    }

    class Links
    {
        public string site { get; set; }
    }
}
