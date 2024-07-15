using MediatR;
using Microsoft.AspNetCore.Http;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ClientToDoList.Commands
{
    public class CreateClientCommand : IRequest<Client>
    {
        public string Firstname { get; set; } = null!;
        public string FirstnameRu { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string LastnameRu { get; set; } = null!;
        [Phone]
        public string Phone { get; set; } = string.Empty;

        public IFormFile Photo { get; set; } = null!;

        // Position
        public string PositionUz { get; set; } = null!;
        public string PositionEn { get; set; } = null!;
        public string PositionRu { get; set; } = null!;
        public string PositionUzRu { get; set; } = null!;

        // Comment
        public string CommentUz { get; set; } = null!;
        public string CommentEn { get; set; } = null!;
        public string CommentRu { get; set; } = null!;
        public string CommentUzRu { get; set; } = null!;
    }
}
