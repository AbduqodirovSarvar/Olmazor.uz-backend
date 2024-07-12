﻿using OlmaTech.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Domain.Entities
{
    public class About : AudiTableEntity
    {
        // Address
        public string AddressUz { get; set; } = null!;
        public string AddressEn { get; set; } = null!;
        public string AddressRu { get; set; } = null!;
        public string AddressUzRu { get; set; } = null!;

        // Title
        public string TitleUz { get; set; } = null!;
        public string TitleEn { get; set; } = null!;
        public string TitleRu { get; set; } = null!;
        public string TitleUzRu { get; set; } = null!;

        // Description
        public string DescriptionUz { get; set; } = null!;
        public string DescriptionEn { get; set; } = null!;
        public string DescriptionRu { get; set; } = null!;
        public string DescriptionUzRu { get; set; } = null!;

        // Description
        public string DescriptionFooterUz { get; set; } = null!;
        public string DescriptionFooterEn { get; set; } = null!;
        public string DescriptionFooterRu { get; set; } = null!;
        public string DescriptionFooterUzRu { get; set; } = null!;

        public int? Experience { get; set; } = null;
        public string Photo { get; set; } = null!;
    }
}
