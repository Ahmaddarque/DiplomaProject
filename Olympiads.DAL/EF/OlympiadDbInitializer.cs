using Olympiads.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Olympiads.DAL.EF
{
    public class OlympiadDbInitializer : DropCreateDatabaseAlways<OlympiadDb>
    {
        private readonly DateTime now = DateTime.Now;
        protected override void Seed(OlympiadDb context)
        {
            #region Visiters
            List<Visiter> visiters = new List<Visiter>() 
            { 
                new Visiter() { IP = "127.0.2.1"},
                new Visiter() { IP = "127.0.2.2"},
                new Visiter() { IP = "127.0.2.3"},
                new Visiter() { IP = "127.0.2.4"},
                new Visiter() { IP = "127.0.2.5"},
                new Visiter() { IP = "127.0.2.6"},
                new Visiter() { IP = "127.0.2.7"},
                new Visiter() { IP = "127.0.2.8"},
                new Visiter() { IP = "127.0.2.9"},
                new Visiter() { IP = "127.0.3.0"},
                new Visiter() { IP = "127.0.3.1"},
                new Visiter() { IP = "127.0.3.2"},
                new Visiter() { IP = "127.0.3.3"},
                new Visiter() { IP = "127.0.3.4"},
                new Visiter() { IP = "127.0.4.5"},
                new Visiter() { IP = "127.0.2.0"},
                new Visiter() { IP = "127.1.2.1"},
            };

            context.Visiters.AddRange(visiters);
            context.SaveChanges();
            #endregion
            #region Visits
            /*
                This Day visits
             */
            foreach (var visiter in visiters)
            {
                context.Visits.Add(new Visit() { Visiter = visiter, VisitTime = now });
            }
            var date = now;
            var rand = new Random();
            for (int i = 0; i < 120; i++)
            {
                int visitsCount = rand.Next(visiters.Count());
                for (int j = 0; j < visitsCount; j++)
                {
                    context.Visits.Add(new Visit() { VisitTime = date,VisiterId = j+1});
                }
                
                date = date.AddDays(-1);
            }

            context.SaveChanges();
            #endregion

            
            #region Admin
            context.Administrators.Add
            (
                new Admin() 
                {
                    Surname = "Васильев",Name = "Иван",Lastname = "Артёмович",PasswordHash= "zdm5c0NZm+o1ZzZP14CGDdWvtZ2W5f8TID9L3NXNYuk0xlmoWzGQK1Ss3+1NDobH0QYm08KsK69kPgSuM+FvPg==",PasswordSalt= "100000.J75HdXd3wJ0vGhM1GonDlMjaDxDfAiahAGuTRK1ykBEClg==",Login = "Landlight" 
                }
            );
            #endregion
            #region Participants
            List<Participant> participants = new List<Participant>()
            {
                new Participant()
                {
                    Name = "Иван",
                    Surname = "Стрельников",
                    Lastname = "Александрович",
                    Birthdate = new DateTime(2001, 9, 7),
                    Login = "Ahmaddark",
                    Password = "zdm5c0NZm+o1ZzZP14CGDdWvtZ2W5f8TID9L3NXNYuk0xlmoWzGQK1Ss3+1NDobH0QYm08KsK69kPgSuM+FvPg==",
                    PasswordSalt = "100000.J75HdXd3wJ0vGhM1GonDlMjaDxDfAiahAGuTRK1ykBEClg==",
                    Phone = "+7(915)2577426",
                    Email = "ddollar78@mail.ru",
                    EducationalInstitution = "ГБПОУ МО \"Серпуховский колледж\"",
                    Sex = Sex.Male,
                    RegistrationIP = "127.0.2.0",
                    RegistrationTime = now
                },
                new Participant()
                {
                    Name = "Иван",
                    Surname = "Роговский",
                    Lastname = "Александрович",
                    Birthdate = new DateTime(2001, 9, 7),
                    Login = "Flubber88",
                    Password = "zdm5c0NZm+o1ZzZP14CGDdWvtZ2W5f8TID9L3NXNYuk0xlmoWzGQK1Ss3+1NDobH0QYm08KsK69kPgSuM+FvPg==",
                    PasswordSalt = "100000.J75HdXd3wJ0vGhM1GonDlMjaDxDfAiahAGuTRK1ykBEClg==",
                    Phone = "+7(915)2573326",
                    Email = "sandsmith@mail.ru",
                    EducationalInstitution = "ГБПОУ МО \"Серпуховский колледж\"",
                    Sex = Sex.Male,
                    RegistrationIP = "127.0.2.1",
                    RegistrationTime = now
                },new Participant()
                {
                    Name = "Иван",
                    Surname = "Роговский",
                    Lastname = "Александрович",
                    Birthdate = new DateTime(2001, 9, 7),
                    Login = "MonsieurMocekel",
                    Password = "zdm5c0NZm+o1ZzZP14CGDdWvtZ2W5f8TID9L3NXNYuk0xlmoWzGQK1Ss3+1NDobH0QYm08KsK69kPgSuM+FvPg==",
                    PasswordSalt = "100000.J75HdXd3wJ0vGhM1GonDlMjaDxDfAiahAGuTRK1ykBEClg==",
                    Phone = "+7(915)2573326",
                    Email = "pusher@mail.ru",
                    EducationalInstitution = "ГБПОУ МО \"Серпуховский колледж\"",
                    Sex = Sex.Male,
                    RegistrationIP = "127.0.2.1",
                    RegistrationTime = now,
                    IsBlocked = true
                },new Participant()
                {
                    Name = "Виталий",
                    Surname = "Медведчиков",
                    Lastname = "Игоревич",
                    Birthdate = new DateTime(2001, 9, 7),
                    Login = "VousAvez",
                    Password = "zdm5c0NZm+o1ZzZP14CGDdWvtZ2W5f8TID9L3NXNYuk0xlmoWzGQK1Ss3+1NDobH0QYm08KsK69kPgSuM+FvPg==",
                    PasswordSalt = "100000.J75HdXd3wJ0vGhM1GonDlMjaDxDfAiahAGuTRK1ykBEClg==",
                    Phone = "+7(915)2573326",
                    Email = "vvv@mail.ru",
                    EducationalInstitution = "ГБПОУ МО \"Серпуховский колледж\"",
                    Sex = Sex.Male,
                    RegistrationIP = "127.0.2.1",
                    RegistrationTime = now.AddDays(-2),
                    IsBlocked = true
                },new Participant()
                {
                    Name = "Семён",
                    Surname = "Хлопотнюк",
                    Lastname = "Васильевич",
                    Birthdate = new DateTime(2001, 9, 7),
                    Login = "NousAvons",
                    Password = "zdm5c0NZm+o1ZzZP14CGDdWvtZ2W5f8TID9L3NXNYuk0xlmoWzGQK1Ss3+1NDobH0QYm08KsK69kPgSuM+FvPg==",
                    PasswordSalt = "100000.J75HdXd3wJ0vGhM1GonDlMjaDxDfAiahAGuTRK1ykBEClg==",
                    Phone = "+7(915)2573326",
                    Email = "vvvv@mail.ru",
                    EducationalInstitution = "ГБПОУ МО \"Серпуховский колледж\"",
                    Sex = Sex.Male,
                    RegistrationIP = "127.0.2.1",
                    RegistrationTime = now.AddDays(-1),
                    IsBlocked = true
                }
            };
            context.Participants.AddRange(participants);
            context.SaveChanges();
            #endregion
            #region Categories
            var student = new ParticipantCategory() { Name = "Студент", IconPath = "~/Content/Img/categories/student.svg" };
            var scholar = new ParticipantCategory() { Name = "Школьник", IconPath = "~/Content/Img/categories/scholar.svg" };
            context.Categories.Add(student);
            context.Categories.Add(scholar);
            #endregion
            context.SaveChanges();
            #region Subjects
            var russian = new Subject() { Name = "Русский язык", IconPath = "~/Content/Img/subjects/russian.svg" };
            var math = new Subject() { Name = "Математика", IconPath = "~/Content/Img/subjects/math.svg" };
            var literature = new Subject() { Name = "Литература", IconPath = "~/Content/Img/subjects/literature.svg" };
            var biology = new Subject() { Name = "Биология", IconPath = "~/Content/Img/subjects/biology.svg" };
            var geo = new Subject() { Name = "География", IconPath = "~/Content/Img/subjects/geography.svg" };
            var it = new Subject() { Name = "Информатика", IconPath = "~/Content/Img/subjects/it.svg" };

            context.Subjects.Add(russian);
            context.Subjects.Add(math);
            context.Subjects.Add(literature);
            context.Subjects.Add(biology);
            context.Subjects.Add(geo);
            context.Subjects.Add(it);
            #endregion
            context.SaveChanges();
            #region Tests
            
            var test = new Test() { Name = "Тестовый тест",IsActive = true, Description = "Очень тестовый тест для теста просто потестить", ParticipantCategoryId = 1, Subject = russian };
            var test2 = new Test() { Name = "Тестовый тест 2", Description = "Очень тестовый тест для теста просто потестить 2", ParticipantCategoryId = 2, Subject = math };
            var test3 = new Test() { Name = "Тестовый тест 3", IsActive = true, Description = "Очень тестовый тест для теста просто потестить 3", ParticipantCategoryId = 1, Subject = biology};
            var test4 = new Test() { Name = "Тестовый тест 4", IsActive = true, Description = "Очень тестовый тест для теста просто потестить 4", ParticipantCategoryId = 2, Subject = geo };
            var test5 = new Test() { Name = "Тестовый тест 5", IsActive = true, Description = "Очень тестовый тест для теста просто потестить 5", ParticipantCategoryId = 1, Subject = it };
            var test6 = new Test() { Name = "Тестовый тест 6", IsActive = true, Description = "Очень тестовый тест для теста просто потестить 6", ParticipantCategoryId = 2, Subject = literature };
            var test7 = new Test() { Name = "Тестовый тест 6", IsActive = true, Description = "Очень тестовый тест для теста просто потестить 6", ParticipantCategoryId = 2, Subject = russian };
            var test8 = new Test() { Name = "Тестовый тест 6", IsActive = true, Description = "Очень тестовый тест для теста просто потестить 6", ParticipantCategoryId = 2, Subject = literature};
            var test9 = new Test() { Name = "Тестовый тест 6", IsActive = true, Description = "Очень тестовый тест для теста просто потестить 6", ParticipantCategoryId = 2,Subject = math };
            var test10 = new Test() { Name = "Тестовый тест 6", IsActive = true, Description = "Очень тестовый тест для теста просто потестить 6", ParticipantCategoryId = 2,  Subject = geo };
            var test11 = new Test() { Name = "Тестовый тест 6", IsActive = true, Description = "Очень тестовый тест для теста просто потестить 6", ParticipantCategoryId = 2, Subject = russian};
            var test12 = new Test() { Name = "Тестовый тест 6", IsActive = true, Description = "Очень тестовый тест для теста просто потестить 6", ParticipantCategoryId = 2 , Subject = literature };
            var test13 = new Test() { Name = "Тестовый тест 6", IsActive = true, Description = "Очень тестовый тест для теста просто потестить 6", ParticipantCategoryId = 2 , Subject = geo };
            var test14 = new Test() { Name = "Тестовый тест 6", IsActive = true, Description = "Очень тестовый тест для теста просто потестить 6", ParticipantCategoryId = 2 , Subject = it };
            var test15 = new Test() { Name = "Тестовый тест 6", IsActive = false, Description = "Очень тестовый тест для теста просто потестить 6", ParticipantCategoryId = 2 , Subject = literature };
            var test16 = new Test() { Name = "Тестовый тест 6", IsActive = true, Description = "Очень тестовый тест для теста просто потестить 6", ParticipantCategoryId = 2 , Subject = russian };
            var test17 = new Test() { Name = "Тестовый тест 6", IsActive = false, Description = "Очень тестовый тест для теста просто потестить 6", ParticipantCategoryId = 2 , Subject = literature };

            context.Tests.Add(test);
            context.Tests.Add(test2);
            context.Tests.Add(test3);
            context.Tests.Add(test4);
            context.Tests.Add(test5);
            context.Tests.Add(test6);
            context.Tests.Add(test7);
            context.Tests.Add(test8);
            context.Tests.Add(test9);
            context.Tests.Add(test10);
            context.Tests.Add(test11);
            context.Tests.Add(test12);
            context.Tests.Add(test13);
            context.Tests.Add(test14);
            context.Tests.Add(test15);
            context.Tests.Add(test16);
            context.Tests.Add(test17);

            context.SaveChanges();
            #endregion
            #region TestTasks
            context.Tasks.Add(new Task()
            {
                Content = "Тестовое задание",
                ActivityId = test.Id,
                Number = 1,
                Options = new List<TaskOption>() {
                    new TaskOption() { Option = "Опция один", IsCorrect = false},
                    new TaskOption() { Option = "Опция два", IsCorrect = false},
                    new TaskOption() { Option = "Опция три", IsCorrect = true}
                }
            });
            context.Tasks.Add(new Task()
            {
                Content = "Выбери правильный ответ",
                ActivityId = test.Id,
                Number = 2,
                Options = new List<TaskOption>() {
                    new TaskOption() { Option = "Опция один", IsCorrect = false},
                    new TaskOption() { Option = "Опция два", IsCorrect = false },
                    new TaskOption() { Option = "Опция три", IsCorrect = true }
                }
            });
            context.Tasks.Add(new Task()
            {
                Content = "Выбери правильный ответ",
                ActivityId = test.Id,
                Number = 2,
                Options = new List<TaskOption>() {
                    new TaskOption() { Option = "Опция один", IsCorrect = false},
                    new TaskOption() { Option = "Опция два", IsCorrect = true },
                    new TaskOption() { Option = "Опция три", IsCorrect = false }
                }
            });
            context.SaveChanges();
            #endregion

            #region olympiads
            List<Olympiad> olympiads = new List<Olympiad>();
            olympiads.Add(new Olympiad()
            {
                Name = "Тестовая олимпиада по географии",
                Subject = geo,
                Category = student,
                Description = string.Empty,
                Minutes = 90,
                CreationTime = DateTime.Now,
                Start = DateTime.Now.AddDays(-2),
                End = DateTime.Now.AddDays(2)
            });
            olympiads.Add(new Olympiad()
            {
                Name = "Тестовая олимпиада по математике",
                Subject = math,
                Category = scholar,
                Description = string.Empty,
                Minutes = 10,
                CreationTime = DateTime.Now,
                Start = DateTime.Now.AddDays(-2),
                End = DateTime.Now.AddDays(2)
            });

            context.Olympiads.Add(olympiads[0]);
            context.Olympiads.Add(olympiads[1]);

            context.SaveChanges();
            #endregion

            #region OlympiadPassings
            context.OlympiadPassings.Add(new OlympiadPassing() { Time = now ,Participant = participants[0],IsPassed = false,Olympiad = olympiads[0]});
            context.OlympiadPassings.Add(new OlympiadPassing() { Time = now ,Participant = participants[1], IsPassed = false,Olympiad = olympiads[0] });
            context.OlympiadPassings.Add(new OlympiadPassing() { Time = now ,Participant = participants[2], IsPassed = false,Olympiad = olympiads[0] });

            context.SaveChanges();
            #endregion
            #region TestPassings
            context.TestPassings.Add(new TestPassing() {Time = now,UserId = 1,TestId=1,IsPassed = false});
            context.TestPassings.Add(new TestPassing() {Time = now,UserId = 1,TestId=1,IsPassed = false});

            context.SaveChanges();
            #endregion
            base.Seed(context);
        }
    }
}