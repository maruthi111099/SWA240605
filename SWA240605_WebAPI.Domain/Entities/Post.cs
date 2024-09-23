﻿using System;
using System.Collections.Generic;

namespace SWA240605_WebAPI.Domain.Entities
{
    public class Post
    {
        public string Code { get; set; } = string.Empty;
        public string Title_Eng { get; set; } = string.Empty;
        public string Title_Lng { get; set; } = string.Empty;
        public string NotificationNo_Eng { get; set; } = string.Empty;
        public string NotificationNo_Lng { get; set; } = string.Empty;
        public int Vacancy { get; set; }
        public DateTime ApplicationStartDate { get; set; }
        public DateTime ApplicationEndDate { get; set; }
        public int ApplicationNoGenerationMode { get; set; }
        //
        //Child entity
        //
        public ICollection<Applicant>? Applicants { get; set; }
        public ICollection<PostUnit>? PostUnits { get; set; }
    }
}
