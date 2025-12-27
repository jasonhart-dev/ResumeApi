using ResumeApi.Dtos;

namespace ResumeApi.Services
{
    public class ResumeService : IResumeService
    {
        private readonly List<ExperienceDto> _experience;
        private readonly List<SkillGroupDto> _skills;
        public IReadOnlyList<SkillGroupDto> GetSkills() => _skills;
        public IReadOnlyList<ExperienceDto> GetExperience()
        {
            return   _experience 
                .OrderBy(e => e.Id)
                .ToList();
        }
        public ExperienceDto? GetExperienceById(int id) => _experience.FirstOrDefault(e => e.Id == id);
        public ResumeService()
        {
            _skills = new List<SkillGroupDto>
            {
                new SkillGroupDto
                {
                    Category = ".NET Development",
                    Skills = new List<string>
                    {
                        "C#", "VB.NET", "WinForms", "ASP.NET", "API Development"
                    }
                },
                new SkillGroupDto
                {
                    Category = "Databases & Reporting",
                    Skills = new List<string>
                    {
                        "SQL Server", "Stored Procedures", "SSRS",
                        "Crystal Reports", "Telerik Reporting"
                    }
                }
            };

            _experience = new List<ExperienceDto>
            {
                new ExperienceDto
                {
                    Id = 5,
                    Company = "USAF Air Force Personnel Center (LCOM PMO)",
                    Title = "Software Developer",
                    DateRange =  "11/2008 – 04/2014",
                    Location = "Randolph AFB, TX",
                    Responsibilities = new List<string>
                    {
                        "Rewrote and maintained the Data Preparation System (DPS) using C# WinForms to support large‑scale Air Force manpower modeling.",
                        "Built custom data import routines (Excel/Text → Proprietary Databases)",
                        "Designed and improved system reports (Crystal Reports) and rebuilt legacy Access databases."
                    },
                    Environment = new []
                    {
                        "C#", "C++", "VB.NET", "WinForms", "MS Access", "Crystal Reports", "VBA", "T-SQL"
                    }

                },
                new ExperienceDto
                {
                    Id = 4,
                    Company = "Preventice Services",
                    Title = "Software Engineer",
                    DateRange =  "04/2014 – 05/2016",
                    Location = "Houston, TX",
                    Responsibilities = new List<string>
                    {
                        "Enhanced and maintained Paceart VBA and C# applications used for real‑time cardiac monitoring workflows",
                        "Developed custom reports in SSRS and created SQL schemas to extend legacy MS Access systems.",
                        "Supported deployment packaging and rollback planning for clinical software."
                    },
                    Environment = new []
                    {
                        "C#", "VBA", "MS Access", "SQL Server 2010", "SSRS", "TFS"
                    }

                },
                new ExperienceDto
                {
                    Id = 3,
                    Company = "Bank of America Merrill Lynch",
                    Title = "Assistant Vice President, Application Support",
                    DateRange =  "05/2016 – 07/2018",
                    Location = "Houston, TX",
                    Responsibilities = new List<string>
                    {
                        "Supported real‑time trading systems generating $450M+ in annual revenue, ensuring uptime and rapid incident response",
                        "Managed deployment of critical applications during after‑hours windows, ensuring smooth releases",
                        "Assisted developers with SQL analysis and troubleshooting in production environments"
                    },
                    Environment = new []
                    {
                        "SQL Server 2010", "SSRS", "Autosys", "Quartz", "Proprietary .NET Tools", "MS Office"
                    }

                },
                new ExperienceDto
                {
                    Id = 2,
                    Company = "Boeing",
                    Title = "Software Engineer III",
                    DateRange = "04/2021 – 03/2022",
                    Location = "Katy, TX (Remote)",
                    Responsibilities = new List<string>
                    {
                        "Developed C# applications for aerospace engineering systems",
                        "Created Telerik reports and unit tests",
                        "Participated in Agile/Scrum ceremonies"
                    },
                    Environment = new []
                    {
                        "Visual Studio 2019", "C# 8.0", "SQLite", "Git", "DevOps", "Telerik Reporting", "Azure DevOps"
                    }
                },
                new ExperienceDto
                {
                    Id = 1,
                    Company = "Peloton Computer Enterprises",
                    Title = "Custom Software Developer",
                    DateRange =  "07/2018 – 04/2021 & 03/2022 – 12/2025",
                    Location = "Katy, TX",
                    Responsibilities = new List<string>
                    {
                        "Delivered custom .NET and VBA applications for enterprise clients",
                        "Built WinForms and API-based integrations",
                        "Led technical discovery and estimates"
                    },
                    Environment = new []
                    {
                       "Visual Studio 2022", "SQL Server 2022", "Peloton SDK", ".NET 4.8", "WellView/SiteView/RigView", "Web API", "Excel VBA", "XML", "WITSML", "Azure DevOps"
                    }

                },
            };

        }
        public ResumeSummaryDto GetSummary()
        {
            return new ResumeSummaryDto
            {
                Name = "Jason Hart",
                Title = "Senior .NET Software Engineer",
                ProfessionalSummary =
                    "Senior Software Engineer with 18+ years of experience designing, " +
                    "modernizing, and supporting enterprise applications across Aerospace, " +
                    "Finance, Defense, Medical, and Oil & Gas industries."
            };
        }



        public EducationDto GetEducation()
        {
            return new EducationDto
            {
                Degree = "B.B.A, Computer Information Systems & Quantitative Methods",
                Institution = "Texas State University",
                Location = "San Marcos, TX"
            };
        }
        
        
    }
}
