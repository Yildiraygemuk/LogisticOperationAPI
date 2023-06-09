﻿using System;
using System.Collections.Generic;

namespace LogisticCompany.Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string LogType { get; set; }
        public DateTime Time { get; set; }
        public int? UserId { get; set; }
        public string MethodName { get; set; }
        public string ClassName { get; set; }
        public List<LogParameter> LogParameters { get; set; }
    }
}