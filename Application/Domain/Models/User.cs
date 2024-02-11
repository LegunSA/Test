using Application.Domain.Models.Checkers;
using System;

namespace Application.Domain.Models
{
    public class User
    {
        private string _email;
        private string _name;
        public Guid Id { get; set; }

        public string Name
        {
            get => _name;
            set { _name = FieldChecker.SetChekedName(value); }
        }

        public string Email
        {
            get => _email;
            set { _email = FieldChecker.SetCheckedEmail(value); }
        }
    }
}
