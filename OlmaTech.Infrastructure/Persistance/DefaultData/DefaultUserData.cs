using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using OlmaTech.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Infrastructure.Persistance.DefaultData
{
    public static class DefaultUserData
    {
        public static User DefaultUser { get; private set; } = null!;

        public static void Initialize(IHashService hashService)
        {
            DefaultUser = new User
            {
                Firstname = "SuperAdmin",
                FirstnameRu = "СуперАдмин",
                Lastname = "SuperAdmin",
                LastnameRu = "СуперАдмин",
                Email = "olma@gmail.com",
                Phone = "+998987654321",
                Gender = Gender.Male,
                Userrole = UserRole.SuperAdmin,
                PasswordHash = hashService.GetHash("Olma123!@#")
            };
        }
    }
}
