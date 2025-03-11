using MoviesRental.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MoviesRental.Domain.Entities
{
    public class Director : Entity
    {
        public const int MIN_LENGTH = 3;
        public const int MAX_LENGTH = 30;

        protected Director() { }

        public Director(string name, string surname) 
        {
            UpdateName(name);
            UpdateSurname(surname);
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        private List<Dvd> _dvds = new List<Dvd>();

        public IReadOnlyList<Dvd> Dvds => _dvds;

        public string FullName()
        {
            return $"{Name} {Surname}";
        }

        public void UpdateName (string name)
        {
            if (!ValidateName(name)) 
                throw new DomainException("Nome inválido para Diretor");
            Name = name;
        }

        public void UpdateSurname (string surname)
        {
            if (!ValidateName(surname))
                throw new DomainException("Sobrenome inválido para Diretor");
            Surname = surname;
        }

        private bool ValidateName (string value)
        {
            if(string.IsNullOrEmpty(value) 
                || value.Length < MIN_LENGTH 
                || value.Length > MAX_LENGTH) 
                return false;

            return Regex.IsMatch(value, @"^[A-Za-z]+$");
        }
    }
}
