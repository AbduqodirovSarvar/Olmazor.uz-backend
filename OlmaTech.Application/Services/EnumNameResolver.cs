using AutoMapper;
using Microsoft.Extensions.Localization;
using OlmaTech.Application.Models;
using System.Globalization;
using System.Resources;

namespace OlmaTech.Application.Services
{
    public class EnumNameResolver<TEnum>(IStringLocalizer<EnumNameResolver<TEnum>> localizer) : IValueResolver<TEnum, EnumViewModel, string> where TEnum : Enum
    {
        private readonly IStringLocalizer<EnumNameResolver<TEnum>> _localizer = localizer;

        public string Resolve(TEnum source, EnumViewModel destination, string destMember, ResolutionContext context)
        {
            var enumTypeName = typeof(TEnum).Name;


            var localizedString = _localizer[$"{enumTypeName}_{source}"];

            var res = _localizer["Gender_Female"].Value;

            return res;
            return localizedString ?? source.ToString();
        }
    }
}
