using MediatR;
using Microsoft.AspNetCore.Http;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.TeamToDoList.Commands
{
    public class UpdateTeamCommand : IRequest<Team>
    {
        [Required]
        public Guid Id { get; set; }

        public string? Firstname { get; set; } = null;
        public string? FirstnameRu { get; set; } = null;
        public string? Lastname { get; set; } = null;
        public string? LastnameRu { get; set; } = null;
        [Phone]
        public string? Phone { get; set; } = null;

        public IFormFile? Photo { get; set; } = null;
        public string? PositionUz { get; set; } = null;
        public string? PositionEn { get; set; } = null;
        public string? PositionRu { get; set; } = null;
        public string? PositionUzRu { get; set; } = null;

        [Url]
        public string? Telegram { get; set; } = null;
        [Url]
        public string? Instagram { get; set; } = null;
        [Url]
        public string? Twitter { get; set; } = null;
        [EmailAddress]
        public string? Email { get; set; } = null;
    }
}
