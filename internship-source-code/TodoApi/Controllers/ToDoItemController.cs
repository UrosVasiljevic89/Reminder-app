using System;
using TodoApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Service;

[ApiController]
[Route("controller")]
public class ToDoItemController : ControllerBase
{
    private readonly ITodoObjectService todoObjectService;
    //static List<ToDoObject> toDoObjects = new List<ToDoObject>();
    private readonly ILogger<ToDoItemController> _logger;

    public ToDoItemController(ITodoObjectService service, ILogger<ToDoItemController> logger){
        this.todoObjectService = service;
        this._logger = logger;
    }
    // public ToDoItemController()
    // {
        
    //     // ToDoObject toDoObject1 = new ToDoObject("Domaci",1,new DateTime(),false);
    //     // ToDoObject toDoObject2 = new ToDoObject("Posao",2,new DateTime(),true);
    //     // ToDoObject toDoObject3 = new ToDoObject("Trening",3,new DateTime(),false);
    //     // ToDoObject toDoObject4 = new ToDoObject("Rodjendan",4,new DateTime(),true);
    //     // ToDoObject toDoObject5 = new ToDoObject("Rest",5,new DateTime(),false);
    //     // toDoObjects.Add(toDoObject1);
    //     // toDoObjects.Add(toDoObject2);
    //     // toDoObjects.Add(toDoObject3);
    //     // toDoObjects.Add(toDoObject4);
    //     // toDoObjects.Add(toDoObject5);
    // }

    [HttpGet(Name = "GetToDoItemController")]
    public IEnumerable<ToDoObject> fetchToDoObjects(){
        try{
            return todoObjectService.fetchToDoObject();
        }catch(Exception e){
            Console.Write(e);
            return null;
        }
        //return toDoObjects;
    }

    [HttpPost(Name = "CreateToDoItemController")]
    public ActionResult<ToDoObject> CreateObject(ToDoObject toDoObj){
        try{
        return todoObjectService.CreateObject(toDoObj);
        }catch(Exception e){
            Console.Write(e);
            return null;
        }
        /*ToDoObject newToDo = new ToDoObject(toDoObj.Title, toDoObj.Id, toDoObj.Date, false);
        
        Random rnd = new Random();
        int n = rnd.Next();
        newToDo.Id = n;

        newToDo.Date = DateTime.Now;
        
        toDoObjects.Add(newToDo);
        return newToDo;*/
    }

    [HttpPut("UpdateToDoObject")]
    public ActionResult<List<ToDoObject>> updateCheck([FromQuery] string id){
        try{
        return todoObjectService.updateCheck(id);
        }catch(Exception e){
            Console.Write(e);
            return null;
        }
        /*try{
        int id2 = Int32.Parse(id);
        foreach(ToDoObject tdo in toDoObjects.ToList()){
            if(tdo.Id == id2){
                toDoObjects.Remove(tdo);
            }
        }
        return toDoObjects;            
        }catch(Exception e){
            Console.Write(e);
            return null;
        }*/

    }

}