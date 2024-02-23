﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class FakeTaskService
    {
        public List<Tarea> Tasks { get; set; }
        public FakeTaskService()
        {
            Tasks = [];
            for (int i = 0; i < 100; i++)
            {
                Tasks.Add(new()
                {
                    Titulo = $"TAREA {i}",
                    Descripcion = $"Tarea.autogenerated {i}",
                });
            }
        }

        public void AddTask(Tarea tarea)
        {
            Tasks.Add(tarea);
        }

        public List<Tarea> GetTasks()
        {
            return Tasks;
        }
    }
}
