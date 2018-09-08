using System;
﻿using RazorLight;

namespace RazorLightTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var md5 = "abcd";
            var content = @"
            @using Microsoft.AspNetCore.Html;
            @model RazorLightTest.Employee;
            <span>@(new HtmlString(Model.Name))</span>";
            
            var emp = new Employee(){
                Name = "<b>Partho</b>"
            };
            
            var razorEngine = new RazorLightEngineBuilder()
            .UseMemoryCachingProvider()
            .Build();
            
            var task = razorEngine.CompileRenderAsync(md5, content, emp);
            task.Wait();
            
            var result = task.Result;
            Console.WriteLine(result);
        }
    }
    
    public class Employee
    {
        public string Name{get;set;}
    }
}
