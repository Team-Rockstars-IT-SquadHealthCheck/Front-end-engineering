﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engineering_ASPNET.DAL
{
    public class SurveyDto
    {
        public int Survey_ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<QuestionDto> Questions { get; set; }
    }
}
