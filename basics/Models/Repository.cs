using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basics.Models
{
    public class Repository
    {
        private static readonly List<Course> _courses = new();
        static Repository()
        {
            _courses = new List<Course>()
            {
            new Course()
            { Id=1,
            Title="asp.net kursu",
            Description="güzeldi",
            Image="1.jpg",
            isActive=true,
            isHome=true,
            Tags=new string[]{"web geliştirme","aspnet"}
            },
           new Course()
           {
            Id=2,
            Title="php kursu",
           Description="güzeldi",
           Image="2.jpg" ,
           isActive=true,
            isHome=true,
            Tags=new string[]{"web geliştirme","php"}
           },
           new Course()
           { Id=3,
           Title="django kursu",
           Description="güzeldi",
           Image="3.jpg",
           isActive=true,
            isHome=true,
           },
           new Course()
           {
            Id=4,
           Title="node js kursu",
           Description="güzeldi",
           Image="4.jpg",
           isActive=false,
            isHome=true,
            }
            };
        }

        public static List<Course> Courses
        {
            get
            {
                return _courses;
            }
        }
        public static Course? GetById(int? id)
        {
            return _courses.FirstOrDefault(c => c.Id == id);
        }
    }
}