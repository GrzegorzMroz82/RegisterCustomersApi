using GameTek.Boundary;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTek.Application
{
    public class RegistrationDto : IUseCaseRequest
    {
        public string BrandId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PersonalNumber { get; set; }
        public string FavoriteFootballTeam { get; set; }
    }
}
