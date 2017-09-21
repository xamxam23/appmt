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
        private static readonly double WANTED_SKILLS_POINT = 1;
        private static readonly double OTHER_SKILLS = 0.5;
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

        public static double calculateWorkExperience(List<WorkExperience> workExperience)
        {
            double results = 0;

            foreach (WorkExperience wExperience in workExperience)
            {
                results = results + (wExperience.months * WORK_EXPERIENCE_POINTS/12);
            }

            return results;
        }

        public static double calculateSkillSet(List<SkillSet> skillSet, List<Criterion> wantedSkillSet)
        {
            double results = 0;

            foreach (SkillSet skill in skillSet)
            {
                if (wantedSkillSet.Count == 0)
                {
                    results += OTHER_SKILLS * skill.skillMonths / 12.0;
                }
                else
                    for (int i = 0; i < wantedSkillSet.Count; i++)
                    {
                        if (skill.skillName.Equals(wantedSkillSet[i].skill))
                        {
                            results = results + WANTED_SKILLS_POINT * skill.skillMonths / 12.0;
                            break;
                        }
                        else
                        {
                            if ((i == (wantedSkillSet.Count - 1)))
                            {
                                results = results + OTHER_SKILLS * skill.skillMonths / 12.0;
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
                    if (QUALIFICATION_POINTS.ContainsKey(qualification.title.ToLower()))
                    results = results + QUALIFICATION_POINTS[qualification.title.ToLower()];
            }
            return results;
        }
    }
}
