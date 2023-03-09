using System;
using TodoApi.Models;
using System.Collections.Generic;

namespace ToDoApi.Repository
{
    public class ToDoObjectRepository : IToDoObjectRepository
    {
        static List<ToDoObject> toDoObjects = new List<ToDoObject>();

        public List<ToDoObject> fetchToDoObject()
        {
            return toDoObjects;
        }

        public ToDoObject CreateObject(ToDoObject toDoObj)
        {

            ToDoObject newToDo = new ToDoObject(toDoObj.Title, toDoObj.Id, toDoObj.Date, false, toDoObj.User);

            Random rnd = new Random();
            int randomValue = rnd.Next(1000);

            int n = rnd.Next();
            if(toDoObj.User == "user1"){
                newToDo.Id = 1 * 1000 + randomValue;
            }
            if(toDoObj.User == "user2"){
                newToDo.Id = 2 * 1000 + randomValue;
            }
            if(toDoObj.User == "user3"){
                newToDo.Id = 3 * 1000 + randomValue;
            }
            if(toDoObj.User == "user4"){
                newToDo.Id = 4 * 1000 + randomValue;
            }
            
            //newToDo.Id = n;

            newToDo.Date = DateTime.Now;

            toDoObjects.Add(newToDo);
            return newToDo;
        }

        public List<ToDoObject> updateCheck(string id)
        {
            try
            {
                int id2 = Int32.Parse(id);
                foreach (ToDoObject tdo in toDoObjects.ToList())
                {
                    if (tdo.Id == id2)
                    {
                        toDoObjects.Remove(tdo);
                    }
                }
                return toDoObjects;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }

        }
    }
}