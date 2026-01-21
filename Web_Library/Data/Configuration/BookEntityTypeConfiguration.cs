using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web_Library.Models;
using Web_Library.Models.Enums;

namespace Web_Library.Data.Configuration
{
    public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
    {

        private readonly Book[] initialBooks = 
        {new Book
        {
            Id = Guid.Parse("b5cebf85-e61a-4e95-b688-a2b0e6893bed"),
            Title = "The Hobbit",
            Author = "J.R.R. Tolkien",
            Genre = Genre.Fantasy
        },
        new Book
        {
             Id = Guid.Parse("eeb61727-49d9-4b67-a836-1d3eacc4f08d"),
             Title = "1984",
             Author = "George Orwell",
             Genre = Genre.ScienceFiction
        },
        new Book
        {
             Id = Guid.Parse("cda5bf3e-e99c-4a9a-bc3c-889ec28b7031"),
             Title = "Brave New World",
             Author = "Aldous Huxley",
             Genre = Genre.ScienceFiction
        },
        new Book
        {
             Id = Guid.Parse("f057357a-d690-48ce-a4cc-e1a9748cc63c"),
             Title = "Clean Code",
             Author = "Robert C. Martin",
             Genre = Genre.Programming
        },
        new Book
        {
             Id = Guid.Parse("43f42ae2-7f5f-4944-871e-52d9fd057e6a"),
             Title = "The Pragmatic Programmer",
             Author = "Andrew Hunt",
             Genre = Genre.Programming
        },
        new Book
        {
             Id = Guid.Parse("5571dd6b-512c-4d64-8620-cf469800d93c"),
             Title = "The Da Vinci Code",
             Author = "Dan Brown",
             Genre = Genre.Thriller
        },
        new Book
        {
             Id = Guid.Parse("e2c70baa-d665-4ace-9409-6b053e41ed4f"),
             Title = "Sherlock Holmes",
             Author = "Arthur Conan Doyle",
             Genre = Genre.Mystery
        },
        new Book
        {
             Id = Guid.Parse("3fb3a2e4-5968-4eac-9838-eec211167561"),
             Title = "It",
             Author = "Stephen King",
             Genre = Genre.Horror
        },
        new Book
        {
             Id = Guid.Parse("65f62571-ee92-4e56-b6b9-dd7a8efe8e3f"),
             Title = "The Shining",
             Author = "Stephen King",
             Genre = Genre.Horror
        },
        new Book
        {
             Id = Guid.Parse("8c263c22-48fd-4ecd-9aa9-e01f2d8c0745"),
             Title = "The Alchemist",
             Author = "Paulo Coelho",
             Genre = Genre.Philosophy
        },
        new Book
        {
             Id = Guid.Parse("f315b770-aba6-4dd3-b9f0-c8b3d0dce787"),
             Title = "Sapiens",
             Author = "Yuval Noah Harari",
             Genre = Genre.History
        },
        new Book
        {
             Id = Guid.Parse("4a8a88ba-79f6-44d6-8701-0c4d6bd7e412"),
             Title = "Homo Deus",
             Author = "Yuval Noah Harari",
             Genre = Genre.History
         },
        new Book
        {
             Id = Guid.Parse("ed7d0f41-9d87-4c33-a0c7-3620ed591fe3"),
             Title = "Steve Jobs",
             Author = "Walter Isaacson",
             Genre = Genre.Biography
        },
        new Book
        {
             Id = Guid.Parse("4f73e635-6290-4152-8c9b-cbcd4d09f496"),
             Title = "The Martian",
             Author = "Andy Weir",
             Genre = Genre.ScienceFiction
        },
        new Book
        {
             Id = Guid.Parse("f15ea439-f2a1-40ac-8278-1056d7a75a52"),
             Title = "Dune",
             Author = "Frank Herbert",
             Genre = Genre.Fantasy
        },
        new Book
        {
             Id = Guid.Parse("1192f7d6-3197-4a88-87ce-a251dd1cf0b3"),
             Title = "The Name of the Wind",
             Author = "Patrick Rothfuss",
             Genre = Genre.Fantasy
        },
        new Book
        {
             Id = Guid.Parse("8be4237a-cadb-4f8c-bfd8-68eab7b7c64e"),
             Title = "To Kill a Mockingbird",
             Author = "Harper Lee",
             Genre = Genre.History
        },
        new Book
        {
             Id = Guid.Parse("3b57c8d7-a88e-4318-b5c4-0d1ab176c2e1"),
             Title = "Pride and Prejudice",
             Author = "Jane Austen",
             Genre = Genre.Romance
        },
        new Book
        {
             Id = Guid.Parse("023fe09a-5ed3-4b7c-8eeb-f323f9e43cbf"),
             Title = "The Great Gatsby",
             Author = "F. Scott Fitzgerald",
             Genre = Genre.Romance
        },
        new Book
        {
             Id = Guid.Parse("b6680038-dd42-4e75-9b24-ab7f2455393d"),
             Title = "Crime and Punishment",
             Author = "Fyodor Dostoevsky",
             Genre = Genre.Philosophy
        },
        new Book
        {
             Id = Guid.Parse("7a183b2a-9af9-4412-9a2d-bcac7383e7ac"),
             Title = "The Catcher in the Rye",
             Author = "J.D. Salinger",
             Genre = Genre.History
         },
        new Book
        {
             Id = Guid.Parse("d292d10e-8797-4b79-be46-150c747a58bf"),
             Title = "Dracula",
             Author = "Bram Stoker",
             Genre = Genre.Horror
        },
        new Book
        {
             Id = Guid.Parse("905974f8-f5b3-4eaf-a143-11b8345aca92"),
             Title = "Fahrenheit 451",
             Author = "Ray Bradbury",
             Genre = Genre.ScienceFiction
        },
        new Book
        {
             Id = Guid.Parse("7f7663d2-b426-4b01-af52-8d617a2fe553"),
             Title = "Refactoring",
             Author = "Martin Fowler",
             Genre = Genre.Programming
        }

        };


        public void Configure(EntityTypeBuilder<Book> entity)
        {
            entity.HasData(initialBooks);
        }
    }
}
