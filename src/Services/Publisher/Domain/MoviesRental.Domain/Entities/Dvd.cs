using MoviesRental.Core.DomainObjects;
using MoviesRental.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Domain.Entities
{
    public class Dvd : Entity
    {

        protected Dvd() { }

        public Dvd(string title, int genre, DateTime published, int copies, Guid directorId)
        {
            Available = true;
            UpdateTitle(title);
            UpdateGenre(genre);
            UpdatePublishedDate(published);
            UpdateCopies(copies);
            UpdateDirector(directorId);
        }
        public string Title { get; private set; }

        public EGenre Genre { get; private set; }

        public DateTime Published { get; private set; }

        public bool Available { get; private set; }

        public int Copies { get; private set; }

        public Guid DiretorId { get; private set; }

        public Director Director { get; set; }

        public const int MIN_TITLE_LENGTH = 2;
        public const int MAX_TITLE_LENGTH = 50;

        public void RentCopy()
        {
            if (Copies == 0 || !Available)
                throw new DomainException($"DVD {Title} não está disponivel para alugar");

            var copier = Copies - 1;
            UpdateCopies(Copies);
        }

        public void ReturnCopy()
        {
            if (!Available)
                throw new DomainException($"DVD {Title} não está disponivel");

            var copier = Copies + 1;
            UpdateCopies(Copies);
        }

        public void UpdateTitle(string title)
        {
            if (!Available)
                throw new DomainException($"DVD {Title} não está disponivel");

            if (string.IsNullOrWhiteSpace(title) ||
                title.Length < MIN_TITLE_LENGTH ||
                title.Length > MAX_TITLE_LENGTH)
                throw new DomainException($"Nome inválido {title} para um dvd");

            Title = title;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateGenre(int genre)
        {
            if (!Available)
                throw new DomainException($"DVD {Title} não está disponivel");


            if (!Enum.IsDefined(typeof(EGenre), genre))
                throw new DomainException("Gênero de DVD inválido!");


            Genre = (EGenre)genre;

            UpdatedAt = DateTime.Now;
        }

        public void UpdatePublishedDate(DateTime date)
        {
            if (!Available)
                throw new DomainException($"DVD {Title} não está disponivel");

            var todayDate = DateTime.Now;

            if (todayDate < date)
            {
                throw new DomainException("A data de publicação não pode ser maior que a data atual ");
            }

            Published = date;
            UpdatedAt = todayDate;
        }

        public void UpdateDirector(Guid directorId)
        {
            if (!Available)
                throw new DomainException($"DVD {Title} não está disponivel");

            if (directorId == Guid.Empty) throw new DomainException($"Id de Diretor inválido");

            DiretorId = directorId;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateCopies(int copies)
        {
            if (!Available)
                throw new DomainException($"DVD {Title} não está disponivel");

            if (copies < 0) throw new DomainException("Número de cópias deve ser maior que zero");

            Copies = copies;
            UpdatedAt = DateTime.Now;
        }

        public void DeleteDvd()
        {
            if (!Available)
                throw new DomainException($"DVD {Title} não está disponivel");

            Available = false;
            Copies = 0;
            DeletedAt = DateTime.Now;
        }

    }
}
