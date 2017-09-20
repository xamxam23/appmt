using ModernUINavigationApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUINavigationApp1.Computation
{
    class Calculator
    {
        private readonly int WORK_EXPERIENCE_POINTS = 2;
        private readonly int WANTED_SKILLS = 2;
        private readonly int OTHER_SKILLS = 1;
        private readonly Dictionary<string, double> QUALIFICATION_POINTS = new Dictionary<string, double>
        {
            { "matric", .25 },
            { "certificate", .5 },
            { "diploma", 1 },
            { "bsc", 4 },
            { "honours", 5 },
            { "masters", 7 },
            { "phd", 10 },
        };

        public int calculateWorkExperience(List<WorkExperience> workExperience)
        {
            int results = 0;

            foreach (WorkExperience wExperience in workExperience)
            {
                results = results + (wExperience.months * WORK_EXPERIENCE_POINTS);
            }

            return results;
        }

        public int calculateSkillSet(List<SkillSet> skillSet, List<SkillSet> wantedSkillSet)
        {
            int results = 0;

            foreach (SkillSet skill in skillSet)
            {
                for (int i = 0; i < wantedSkillSet.Count; i++)
                {
                    if (skill.skillName.Equals(wantedSkillSet[i]) && (i == (wantedSkillSet.Count - 1)))
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

        public double calculateWorkQualifications(Qualifications qualification)
        {
            return QUALIFICATION_POINTS[qualification.title.ToLower()];
        }
    }
}
