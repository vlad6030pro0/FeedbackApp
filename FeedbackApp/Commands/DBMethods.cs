using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackApp.Models.DBModels;
using FeedbackApp.Models.Models;
using FeedbackApp.Context;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApp
{
    public class DBMethods
    {
        public static FBContext context = new FBContext();
        public static void AddUser(string username, int chatId)
        {
            bool isHave = false;

            foreach (var user in context.users)
            {
                if(user.Name==username)
                {
                    isHave = true;
                }
            }

            if(isHave==false)
            {
                User user = new User()
                {
                    Name = username,
                    ChatId = chatId
                };
                context.Add(TransformToDBUser(user));
                context.SaveChanges();
                Console.WriteLine("[AU]: Пользователь добавлен в базу данных.");
            }
            else
            {
                Console.WriteLine("[AU]: Пользователь с таким именем уже есть в базе данных.");
            }
        }
        public static void AddMessage(string messagetext, int iduser)
        {
            bool isHave = false;

            foreach (var user in context.users)
            {
                if (user.Id==iduser)
                {
                    isHave = true;
                }
            }

            if(isHave)
            {
                Message message = new Message()
                {
                    Text = messagetext,
                    IdUser = iduser
                };
                context.Add(TransformToDBMessage(message));
                context.SaveChanges();
                Console.WriteLine("[AM]: Сообщение записано в базу данных.");
            }
            else
            {
                Console.WriteLine("[AM]: Пользователь отсутствует в базе данных.");
            }
        }
        public static User FindUserByUsername(string username)
        {
            User user = null;
            foreach(var userDB in context.users)
            {
                if (userDB.Name==username)
                {
                    user = TransformToUser(userDB);
                }
            }

            if (user!=null)
            {
                return user;
            }
            else
            {
                Console.WriteLine("[FUBU]: Пользователь отсутствует в базе данных.");
                return user;
            }
        }
        public static DBUser TransformToDBUser(User user)
        {
            return new DBUser() { Id = user.Id, Name = user.Name, ChatId = user.ChatId};
        }
        public static User TransformToUser(DBUser dbuser)
        {
            return new User() { Id = dbuser.Id, Name = dbuser.Name, ChatId = dbuser.ChatId };
        }
        public static DBMessage TransformToDBMessage(Message message)
        {
            return new DBMessage() { Id = message.Id, Text = message.Text, IdUser = message.IdUser};
        }
    }
}
