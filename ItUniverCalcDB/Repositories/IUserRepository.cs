using ItUniverCalcDB.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ItUniverCalcDB.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        /// <summary>
        /// Проверка: есть ли в базе такой пользователь
        /// </summary>
        /// <param name="login">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        bool Check(string login, string password);
        

        /// <summary>
        /// Загрузить пользователя по имени
        /// </summary>
        /// <param name="login">Имя пользователя</param>
        /// <returns></returns>
        User GetByName(string login);

        //void Saves(string name, string login, string password, Boolean sex, DateTime birhtday);

        void Saver(User item);
    }
}
