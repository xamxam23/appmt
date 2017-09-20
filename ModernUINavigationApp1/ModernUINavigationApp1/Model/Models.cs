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
        private string userName;
        private int userAge;
        private int userRating;
        private List<SkillSet> userSkillSet;
        private List<WorkExperience> userWorkExperience;
        private List<Qualifications> userQualifications;
        private List<References> userReferences;
        private List<Links> userLinks;

        public string name
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }
        public int age
        {
            get
            {
                return userAge;
            }
            set
            {
                userAge = value;
            }
        }
        public int rating
        {
            get
            {
                return userRating;
            }
            set
            {
                userRating = value;
            }
        }
        public List<SkillSet> skillSet
        {
            get
            {
                return userSkillSet;
            }
            set
            {
                userSkillSet = value;
            }
        }
        public List<WorkExperience> workExperience
        {
            get
            {
                return userWorkExperience;
            }
            set
            {
                userWorkExperience = value;
            }
        }
        public List<Qualifications> qualifications
        {
            get
            {
                return userQualifications;
            }
            set
            {
                userQualifications = value;
            }
        }
        public List<References> references
        {
            get
            {
                return userReferences;
            }
            set
            {
                userReferences = value;
            }
        }
        public List<Links> links
        {
            get
            {
                return userLinks;
            }
            set
            {
                userLinks = value;
            }
        }
    }

    public class SkillSet
    {
        public string skillName;
        public int skillMonths;
        public int skillRating;

        public string name
        {
            get
            {
                return skillName;
            }
            set
            {
                skillName = value;
            }
        }
        public int months
        {
            get
            {
                return skillMonths;
            }
            set
            {
                skillMonths = value;
            }
        }
        public int rating
        {
            get
            {
                return skillRating;
            }
            set
            {
                skillRating = value;
            }
        }
    }

    public class WorkExperience
    {
        private string workExperienceperCompany;
        private string workExperiencePosition;
        private int workExperienceMonths;

        public string company
        {
            get
            {
                return workExperienceperCompany;
            }
            set
            {
                workExperienceperCompany = value;
            }
        }
        public string position
        {
            get
            {
                return workExperiencePosition;
            }
            set
            {
                workExperiencePosition = value;
            }
        }
        public int months
        {
            get
            {
                return workExperienceMonths;
            }
            set
            {
                workExperienceMonths = value;
            }
        }
    }

    public class Qualifications
    {
        private string qualificationsTitle;
        private string qualificationsInstitution;
        private int qualificationsYear;

        public string title
        {
            get
            {
                return qualificationsTitle;
            }
            set
            {
                qualificationsTitle = value;
            }
        }
        public string institution
        {
            get
            {
                return qualificationsInstitution;
            }
            set
            {
                qualificationsInstitution = value;
            }
        }
        public int year
        {
            get
            {
                return qualificationsYear;
            }
            set
            {
                qualificationsYear = value;
            }
        }
    }

    public class References
    {
        private string referencesName;
        private string referencesEmail;
        private string referencesPhone;
        private string referencesCompany;

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