using ModernUINavigationApp1.Model;
using ModernUINavigationApp1.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUINavigationApp1.Computation
{
    class Calculator
    {
        private static readonly int WORK_EXPERIENCE_POINTS = 2;
        private static readonly int WANTED_SKILLS = 2;
        private static readonly int OTHER_SKILLS = 1;
        private static readonly Dictionary<string, double> QUALIFICATION_POINTS = new Dictionary<string, double>
        {
            { "matric", .25 },
            { "certificate", .5 },
            { "diploma", 1 },
            { "degree", 4 },
            { "honours", 5 },
            { "masters", 7 },
            { "phd", 10 },
        };

        public static int calculateWorkExperience(List<WorkExperience> workExperience)
        {
            int results = 0;

            foreach (WorkExperience wExperience in workExperience)
            {
                results = results + (wExperience.months * WORK_EXPERIENCE_POINTS);
            }

            return results;
        }

        public static int calculateSkillSet(List<SkillSet> skillSet, List<Criterion> wantedSkillSet)
        {
            int results = 0;

            foreach (SkillSet skill in skillSet)
            {
                for (int i = 0; i < wantedSkillSet.Count; i++)
                {
                    if (skill.skillName.Equals(wantedSkillSet[i].minQualifications))
                    {
                        results = results + WANTED_SKILLS;
                        break;
                    }
                    else
                    {
                        if ((i == (wantedSkillSet.Count - 1)))
                        {
                            results = results + OTHER_SKILLS;
                        }
                    }
                }
            }

            return results;
        }

        public static double calculateWorkQualifications(List<Qualifications> qualifications)
        {
            double results = 0;
            foreach (Qualifications qualification in qualifications)
            {
                results = results + QUALIFICATION_POINTS[qualification.title.ToLower()];
            }
            return results;
        }
    }
}
