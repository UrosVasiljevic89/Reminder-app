using System;
using TodoApi.Models;
using System.Collections.Generic;
using ToDoApi.Repository;

namespace ToDoApi.Service
{
    public class ToDoObjectService : ITodoObjectService
    {
        //static List<ToDoObject> toDoObjects = new List<ToDoObject>();

        private readonly IToDoObjectRepository todoObjectRespository;
        public ToDoObjectService(IToDoObjectRepository service)
        {
            this.todoObjectRespository = service;

        }
        public List<ToDoObject> fetchToDoObject()
        {
            return todoObjectRespository.fetchToDoObject();
            //return toDoObjects;
        }

        public ToDoObject CreateObject(ToDoObject toDoObj)
        {
            return todoObjectRespository.CreateObject(toDoObj);
            /*ToDoObject newToDo = new ToDoObject(toDoObj.Title, toDoObj.Id, toDoObj.Date, false);

            Random rnd = new Random();
            int n = rnd.Next();
            newToDo.Id = n;

            newToDo.Date = DateTime.Now;

            toDoObjects.Add(newToDo);
            return newToDo;*/
        }

        public List<ToDoObject> updateCheck(string id)
        {
            return todoObjectRespository.updateCheck(id);
            /*try
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
            }*/

        }
    }
}