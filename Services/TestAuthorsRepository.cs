using System;
using System.Collections.Generic;
using Fisher.Bookstore.Models;

namespace Fisher.Bookstore.Services
{

    public class TestAuthorsRepository : IAuthorsRepository
    {
        private Dictionary<int, Author> authors;
        public TestAuthorsRepository()
        {
            authors = new Dictionary<int, Author>();

            new List<Author>{
                new Author{Name="J.K Rowling"},
                new Author{Name="Margaret Atwood"},
                new Author{Name="Ursula Le Guin"},
            }.ForEach(a => this.AddAuthor(a));
        }
        public int AddAuthor(Author author)
        {
            if (author.Id == 0)
            {
                int key = authors.Count + 1;
                while (authors.ContainsKey(key))
                {
                    key++;
                }
                author.Id = key;
            }
            authors[author.Id] = author;
            return author.Id;
        }

        public void DeleteAuthor(int authorId)
        {
            authors.Remove(authorId);
        }

        public Author GetAuthor(int authorId)
        {
            return authors.GetValueOrDefault(authorId);
        }

        public IEnumerable<Author> GetAuthors()
        {
            return authors.Values;
        }

        public IEnumerable<Book> GetBooksByAuthor(int authorId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateAuthor(Author author)
        {
            authors[author.Id] = author;
        }

        public bool AuthorExists(int authorId)
        {
            return authors.ContainsKey(authorId);
        }
    }
}