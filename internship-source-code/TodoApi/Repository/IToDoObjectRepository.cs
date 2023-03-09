using System;
using TodoApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ToDoApi.Repository
{
    public interface IToDoObjectRepository
    {
        List<ToDoObject> fetchToDoObject();
        ToDoObject CreateObject(ToDoObject toDoObj);
        List<ToDoObject> updateCheck(string id);
    }
}