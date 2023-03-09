using System;
using TodoApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApi.Repository;


namespace ToDoApi.Service
{
    public interface ITodoObjectService
    {
        List<ToDoObject> fetchToDoObject();
        ToDoObject CreateObject(ToDoObject toDoObj);
        List<ToDoObject> updateCheck(string id);

    }
}