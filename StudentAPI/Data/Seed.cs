using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Entities;
using StudentAPI.Entities.IdentityEntities;
using StudentAPI.Helper;

namespace StudentAPI.Data
{
    public static class Seed
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using (var scope =
                app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetRequiredService<StudentDataContext>();
                    context.Database.Migrate();
                    Init(scope);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }
        }

        private static void Init(IServiceScope scope)
        {
            try
            {
                var db = scope.ServiceProvider.GetRequiredService<StudentDataContext>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
                var dbPerson = scope.ServiceProvider.GetRequiredService<UserManager<Person>>();
                if (!roleManager.Roles.Any())
                {
                    var result = roleManager.CreateAsync(new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),
                        Name = "User"
                    }).Result;
                }
                if (!db.Courses.Any())
                {
                    db.Courses.Add(new Course()
                    {
                        Create = DateTime.Now,
                        Name = "Математика"
                    });
                    db.Courses.Add(new Course()
                    {
                        Create = DateTime.Now,
                        Name = "Иностранные языки"
                    });
                    db.Courses.Add(new Course()
                    {
                        Create = DateTime.Now,
                        Name = "Айти"
                    });

                    db.SaveChanges();
                }
                if (!db.Groups.Any())
                {
                    db.Groups.Add(new Group()
                    {
                        Create = DateTime.Now,
                        Name = "НБО2007"
                    });
                    db.SaveChanges();
                }
                if (!dbPerson.Users.Any())
                {
                    var eduard = new Student()
                    {
                        // добавить ебанный студенчиский всем пидорам 
                        Id = Guid.NewGuid(),
                        Create = DateTime.Now,
                        UserName = "Eduard",
                        Name = "Эдуард Олегович",
                        Surname = "Пахомов",
                        Email = "eduard@misis.ru",
                        PhoneNumber = "1534567890",
                        TimePass = 0,
                        StudentCard = "2100960",
                        Group = db.Groups.FirstOrDefault(f => f.Name == "НБО2007"),
                    };
                    var aleksandra = new Student()
                    {
                        Id = Guid.NewGuid(),
                        Create = DateTime.Now,
                        UserName = "Aleksandra",
                        Name = "Александра Романовна",
                        Surname = "Пахомова",
                        Email = "aleksandra@misis.ru",
                        PhoneNumber = "1234567891",
                        TimePass = 0,
                        StudentCard = "2100901",
                        Group = db.Groups.FirstOrDefault(f => f.Name == "НБО2007"),
                    };
                    var bohdan = new Student()
                    {
                        Id = Guid.NewGuid(),
                        Create = DateTime.Now,
                        UserName = "Bohdan",
                        Name = "Богдан Александрович",
                        Surname = "Вознюк",
                        Email = "bohdan@misis.ru",
                        PhoneNumber = "1234567892",
                        TimePass = 0,
                        StudentCard = "2100992",
                        Group = db.Groups.FirstOrDefault(f => f.Name == "НБО2007"),
                    };
                    var dmitriy = new Student()
                    {
                        Id = Guid.NewGuid(),
                        Create = DateTime.Now,
                        UserName = "Dmitriy",
                        Name = "Дмитрий Владимирович",
                        Surname = "Воронов",
                        Email = "dmitriy@misis.ru",
                        PhoneNumber = "1234567893",
                        TimePass = 0,
                        StudentCard = "2100973",
                        Group = db.Groups.FirstOrDefault(f => f.Name == "НБО2007"),
                    };

                    //

                    var maria = new Student()
                    {
                        Id = Guid.NewGuid(),
                        Create = DateTime.Now,
                        UserName = "Maria",
                        Name = "Мария Анатолиевна",
                        Surname = "Воронцова",
                        Email = "maria@misis.ru",
                        PhoneNumber = "1534567894",
                        TimePass = 0,
                        StudentCard = "2100914",
                        Group = db.Groups.FirstOrDefault(f => f.Name == "НБО2007"),
                    };
                    var anna = new Student()
                    {
                        Id = Guid.NewGuid(),
                        Create = DateTime.Now,
                        UserName = "Anna",
                        Name = "Анна Богдановна",
                        Surname = "Богдак",
                        Email = "anna@misis.ru",
                        PhoneNumber = "1234567895",
                        TimePass = 0,
                        StudentCard = "2100985",
                        Group = db.Groups.FirstOrDefault(f => f.Name == "НБО2007"),
                    };
                    var taras = new Student()
                    {
                        Id = Guid.NewGuid(),
                        Create = DateTime.Now,
                        UserName = "Taras",
                        Name = "Тарас Борисович",
                        Surname = "Левчук",
                        Email = "taras@misis.ru",
                        PhoneNumber = "1234567896",
                        TimePass = 0,
                        StudentCard = "2100936",
                        Group = db.Groups.FirstOrDefault(f => f.Name == "НБО2007"),
                    };
                    var boris = new Student()
                    {
                        Id = Guid.NewGuid(),
                        Create = DateTime.Now,
                        UserName = "Boris",
                        Name = "Борис Тарасович",
                        Surname = "Щербак",
                        Email = "boris@misis.ru",
                        PhoneNumber = "1234567897",
                        TimePass = 0,
                        StudentCard = "2100957",
                        Group = db.Groups.FirstOrDefault(f => f.Name == "НБО2007"),
                    };





                    var resultEduard = dbPerson.CreateAsync(eduard, "1234").Result;
                    var resultAleksandra = dbPerson.CreateAsync(aleksandra, "1234").Result;
                    var resultBohdan = dbPerson.CreateAsync(bohdan, "1234").Result;
                    var resultDmitry = dbPerson.CreateAsync(dmitriy, "1234").Result;

                    var resultMaria = dbPerson.CreateAsync(maria, "1234").Result;
                    var resultAnna = dbPerson.CreateAsync(anna, "1234").Result;
                    var resultTaras = dbPerson.CreateAsync(taras, "1234").Result;
                    var resultBoris = dbPerson.CreateAsync(boris, "1234").Result;

                    if (resultEduard.Succeeded)
                    {
                        resultEduard = dbPerson.AddToRoleAsync(eduard, "User").Result;
                    }
                    if (resultAleksandra.Succeeded)
                    {
                        resultAleksandra = dbPerson.AddToRoleAsync(aleksandra, "User").Result;
                    }
                    if (resultBohdan.Succeeded)
                    {
                        resultBohdan = dbPerson.AddToRoleAsync(bohdan, "User").Result;
                    }
                    if (resultDmitry.Succeeded)
                    {
                        resultDmitry = dbPerson.AddToRoleAsync(dmitriy, "User").Result;
                    }
                    // ----
                    if (resultMaria.Succeeded)
                    {
                        resultMaria = dbPerson.AddToRoleAsync(maria, "User").Result;
                    }
                    if (resultAnna.Succeeded)
                    {
                        resultAnna = dbPerson.AddToRoleAsync(anna, "User").Result;
                    }
                    if (resultTaras.Succeeded)
                    {
                        resultTaras = dbPerson.AddToRoleAsync(taras, "User").Result;
                    }
                    if (resultBoris.Succeeded)
                    {
                        resultBoris = dbPerson.AddToRoleAsync(boris, "User").Result;
                    }


                    var kristina = new Teacher()
                    {
                        Id = Guid.NewGuid(),
                        Create = DateTime.Now,
                        UserName = "Kristina",
                        Name = "Кристина",
                        Surname = "Пахомова",
                        Email = "kristina@misis.ru",
                        PhoneNumber = "1234577891",
                    };
                    var igor = new Teacher()
                    {
                        Id = Guid.NewGuid(),
                        Create = DateTime.Now,
                        UserName = "Igor",
                        Name = "Игорь",
                        Surname = "Воронов",
                        Email = "igor@misis.ru",
                        PhoneNumber = "1239567891",
                    };
                    var resultKristina = dbPerson.CreateAsync(kristina, "1234").Result;
                    var resultIgor = dbPerson.CreateAsync(igor, "1234").Result;

                    if (resultKristina.Succeeded)
                    {
                        resultKristina = dbPerson.AddToRoleAsync(kristina, "User").Result;
                    }
                    if (resultIgor.Succeeded)
                    {
                        resultIgor = dbPerson.AddToRoleAsync(igor, "User").Result;
                    }
                }
                if (!db.UniversityTrackers.Any())
                {
                    db.UniversityTrackers.Add(new UniversityTracker() { 
                        Create = DateTime.Now,
                        Visit = false,
                        Student = dbPerson.FindByEmailAsync("eduard@misis.ru").Result as Student,
                    });
                    db.UniversityTrackers.Add(new UniversityTracker()
                    {
                        Create = DateTime.Now,
                        Visit = false,
                        Student = dbPerson.FindByEmailAsync("aleksandra@misis.ru").Result as Student,
                    });
                    db.UniversityTrackers.Add(new UniversityTracker()
                    {
                        Create = DateTime.Now,
                        Visit = false,
                        Student = dbPerson.FindByEmailAsync("bohdan@misis.ru").Result as Student,
                    });
                    db.UniversityTrackers.Add(new UniversityTracker()
                    {
                        Create = DateTime.Now,
                        Visit = false,
                        Student = dbPerson.FindByEmailAsync("dmitriy@misis.ru").Result as Student,
                    });

                    db.UniversityTrackers.Add(new UniversityTracker()
                    {
                        Create = DateTime.Now,
                        Visit = false,
                        Student = dbPerson.FindByEmailAsync("maria@misis.ru").Result as Student,
                    });
                    db.UniversityTrackers.Add(new UniversityTracker()
                    {
                        Create = DateTime.Now,
                        Visit = false,
                        Student = dbPerson.FindByEmailAsync("anna@misis.ru").Result as Student,
                    });
                    db.UniversityTrackers.Add(new UniversityTracker()
                    {
                        Create = DateTime.Now,
                        Visit = false,
                        Student = dbPerson.FindByEmailAsync("taras@misis.ru").Result as Student,
                    });
                    db.UniversityTrackers.Add(new UniversityTracker()
                    {
                        Create = DateTime.Now,
                        Visit = false,
                        Student = dbPerson.FindByEmailAsync("boris@misis.ru").Result as Student,
                    });
                    db.SaveChanges();
                }
                //End today Here 
                if (!db.Lessons.Any())
                {
                    db.Lessons.Add(new Lesson()
                    {
                        Name = "Высшая математика",
                        StartTime = DateTime.Now,
                        Create = DateTime.Now,
                        Course = db.Courses.FirstOrDefault(f => f.Name == "Математика"),           
                    });
                    db.Lessons.Add(new Lesson()
                    { 
                        Name = "Мат анализ",
                        StartTime = DateTime.Now,
                        Create = DateTime.Now,
                        Course = db.Courses.FirstOrDefault(f => f.Name == "Математика"),
                    });
                    db.Lessons.Add(new Lesson()
                    {
                        Name = "Алгебра",
                        StartTime = DateTime.Now,
                        Create = DateTime.Now,
                        Course = db.Courses.FirstOrDefault(f => f.Name == "Математика"),
                    });

                    db.Lessons.Add(new Lesson()
                    {
                        Name = "Английский язык",
                        StartTime = DateTime.Now,
                        Create = DateTime.Now,
                        Course = db.Courses.FirstOrDefault(f => f.Name == "Иностранные языки"),
                    });
                    db.Lessons.Add(new Lesson()
                    {
                        Name = "Французский язык",
                        StartTime = DateTime.Now,
                        Create = DateTime.Now,
                        Course = db.Courses.FirstOrDefault(f => f.Name == "Иностранные языки"),
                    });
                    db.Lessons.Add(new Lesson()
                    {
                        Name = "Арабский язык",
                        StartTime = DateTime.Now,
                        Create = DateTime.Now,
                        Course = db.Courses.FirstOrDefault(f => f.Name == "Иностранные языки"),
                    });

                    db.Lessons.Add(new Lesson()
                    {
                        Name = "Програмирование на языке С++",
                        StartTime = DateTime.Now,
                        Create = DateTime.Now,
                        Course = db.Courses.FirstOrDefault(f => f.Name == "Айти"),
                    });
                    db.Lessons.Add(new Lesson()
                    {
                        Name = "Введение Базы Данных",
                        StartTime = DateTime.Now,
                        Create = DateTime.Now,
                        Course = db.Courses.FirstOrDefault(f => f.Name == "Айти"),
                    });
                    db.Lessons.Add(new Lesson()
                    {
                        Name = "React для чайников",
                        StartTime = DateTime.Now,
                        Create = DateTime.Now,
                        Course = db.Courses.FirstOrDefault(f => f.Name == "Айти"),
                    });

                    db.SaveChanges();
                }
                if (!db.Schedules.Any())
                {
                    db.Schedules.Add(new Schedule()
                    {
                        Create = DateTime.Now,
                        Date = new DateTime(2022, 5, 20),              
                    });
                    db.Schedules.Add(new Schedule()
                    {
                        Create = DateTime.Now,
                        Date = new DateTime(2022, 5, 21),
                    });
                    db.Schedules.Add(new Schedule()
                    {
                        Create = DateTime.Now,
                        Date = new DateTime(2022, 5, 22),
                    });
                    db.SaveChanges();
                }
                if (!db.ScheduleCourses.Any())
                {
                    db.ScheduleCourses.Add(new ScheduleCourse()
                    {
                        Create = DateTime.Now,
                        Teacher = dbPerson.FindByEmailAsync("kristina@misis.ru").Result as Teacher,
                        Course = db.Courses.FirstOrDefault(f => f.Name == "Математика"),
                        Schedule = db.Schedules.FirstOrDefault(f => f.Date.Day == 20),
                    });
                    db.ScheduleCourses.Add(new ScheduleCourse()
                    {
                        Create = DateTime.Now,
                        Teacher = dbPerson.FindByEmailAsync("kristina@misis.ru").Result as Teacher,
                        Course = db.Courses.FirstOrDefault(f => f.Name == "Иностранные языки"),
                        Schedule = db.Schedules.FirstOrDefault(f => f.Date.Day == 21),
                    });

                    db.ScheduleCourses.Add(new ScheduleCourse()
                    {
                        Create = DateTime.Now,
                        Teacher = dbPerson.FindByEmailAsync("kristina@misis.ru").Result as Teacher,
                        Course = db.Courses.FirstOrDefault(f => f.Name == "Айти"),
                        Schedule = db.Schedules.FirstOrDefault(f => f.Date.Day == 22),
                    });
                    db.SaveChanges();
                }
                if (!db.StudentLessons.Any())
                {

                    foreach (var item in db.Lessons.ToList())
                    { 
                        db.StudentLessons.Add(new StudentLesson()
                        {
                            Create = DateTime.Now,
                            LessonVisit = false,
                            DateLose = DateTime.Now,
                            Student = dbPerson.FindByEmailAsync("eduard@misis.ru").Result as Student,
                            Lesson = db.Lessons.FirstOrDefault(f => f.Name == item.Name),
                        });
                        db.StudentLessons.Add(new StudentLesson()
                        {
                            Create = DateTime.Now,
                            LessonVisit = false,
                            DateLose = DateTime.Now,
                            Student = dbPerson.FindByEmailAsync("aleksandra@misis.ru").Result as Student,
                            Lesson = db.Lessons.FirstOrDefault(f => f.Name == item.Name),
                        });
                        db.StudentLessons.Add(new StudentLesson()
                        {
                            Create = DateTime.Now,
                            LessonVisit = false,
                            DateLose = DateTime.Now,
                            Student = dbPerson.FindByEmailAsync("bohdan@misis.ru").Result as Student,
                            Lesson = db.Lessons.FirstOrDefault(f => f.Name == item.Name),
                        });
                        db.StudentLessons.Add(new StudentLesson()
                        {
                            Create = DateTime.Now,
                            LessonVisit = false,
                            DateLose = DateTime.Now,
                            Student = dbPerson.FindByEmailAsync("dmitriy@misis.ru").Result as Student,
                            Lesson = db.Lessons.FirstOrDefault(f => f.Name == item.Name),
                        });

                        db.StudentLessons.Add(new StudentLesson()
                        {
                            Create = DateTime.Now,
                            LessonVisit = false,
                            DateLose = DateTime.Now,
                            Student = dbPerson.FindByEmailAsync("maria@misis.ru").Result as Student,
                            Lesson = db.Lessons.FirstOrDefault(f => f.Name == item.Name),
                        });
                        db.StudentLessons.Add(new StudentLesson()
                        {
                            Create = DateTime.Now,
                            LessonVisit = false,
                            DateLose = DateTime.Now,
                            Student = dbPerson.FindByEmailAsync("anna@misis.ru").Result as Student,
                            Lesson = db.Lessons.FirstOrDefault(f => f.Name == item.Name),
                        });
                        db.StudentLessons.Add(new StudentLesson()
                        {
                            Create = DateTime.Now,
                            LessonVisit = false,
                            DateLose = DateTime.Now,
                            Student = dbPerson.FindByEmailAsync("taras@misis.ru").Result as Student,
                            Lesson = db.Lessons.FirstOrDefault(f => f.Name == item.Name),
                        });
                        db.StudentLessons.Add(new StudentLesson()
                        {
                            Create = DateTime.Now,
                            LessonVisit = false,
                            DateLose = DateTime.Now,
                            Student = dbPerson.FindByEmailAsync("boris@misis.ru").Result as Student,
                            Lesson = db.Lessons.FirstOrDefault(f => f.Name == item.Name),
                        });
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
