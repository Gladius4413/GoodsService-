﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goods.Core.Models
{
    public class Users
    {
        public Guid Id { get;}
        public string Name { get;} = string.Empty;

        public string Surname { get;} = string.Empty;
        
        public string Mail { get;} = string.Empty;
        public string Password { get;} = string.Empty;

        public Users(Guid id, string name, string surname, string mail, string password)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Mail = mail;
            Password = password;
        }

        public static (Users User, string Error) Create(Guid id, string name, string surname, string mail, string password)
        {
            var error = string.Empty;

            if(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(mail) || string.IsNullOrWhiteSpace(password))
            {
                error = "Error, check your data";
            }

            var user = new Users(id, name, surname, mail, password);

            return (user, error);
        }

    }
}
