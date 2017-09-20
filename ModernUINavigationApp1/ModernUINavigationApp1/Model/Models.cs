using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUINavigationApp1.Model
{
    public class CVScored
    {
        [System.ComponentModel.Browsable(false)]
        public string user { get; set; }
        public string name { get; set; }

        public double qualificationScore { get; set; }
        public double workScore { get; set; }
        public double skillScore { get; set; }

        public double totalScore
        {
            get
            {
                return qualificationScore + workScore + skillScore;
            }
        }
    }
    public class CVInfo
    {
        public string name { get; set; }
        public int age { get; set; }
        public int rating { get; set; }
    }

    public class SkillSet
    {
        public string name { get; set; }
        public int months { get; set; }
        public int rating { get; set; }
    }

    public class WorkExperience
    {
        public string company { get; set; }
        public string position { get; set; }
        public int months { get; set; }
    }

    public class Qualifications
    {
        public string title { get; set; }
        public string institution { get; set; }
        public int year { get; set; }
    }

    public class References
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string company { get; set; }
    }

    public class Links
    {
        public string site { get; set; }
    }
}
