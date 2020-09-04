using Moq;
using NUnit.Framework;
using SQLServer.Task7.Domain.Models;
using SQLServer.Task7.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SQLServer.Task7.PresentationTests
{
    /// <summary>
    /// Mock base class to simulete data from tables.
    /// </summary>
    public class MockBaseView
    {
        /// <summary>
        /// Exam schedules table.
        /// </summary>
        public IQueryable<Examiners> Examiners { get; set; }

        /// <summary>
        /// Exam schedules table.
        /// </summary>
        public IQueryable<ExamSchedules> ExamSchedules { get; set; }

        /// <summary>
        /// Specialties table.
        /// </summary>
        public IQueryable<Specialties> Specialties { get; set; }

        /// <summary>
        /// Groups table.
        /// </summary>
        public IQueryable<Groups> Groups { get; set; }

        /// <summary>
        /// Sessions table.
        /// </summary>
        public IQueryable<Sessions> Sessions { get; set; }

        /// <summary>
        /// Sessions results table.
        /// </summary>
        public IQueryable<SessionsResults> SessionsResults { get; set; }

        /// <summary>
        /// Students table.
        /// </summary>
        public IQueryable<Students> Students { get; set; }

        /// <summary>
        /// Subjects table.
        /// </summary>
        public IQueryable<Subjects> Subjects { get; set; }

        /// <summary>
        /// Mock property.
        /// </summary>
        public Mock<ITables> Mock { get; set; }

        /// <summary>
        /// Initialize property tables.
        /// </summary>
        [SetUp]
        public void InitialMock()
        {
            Examiners = new List<Examiners>()
            {
               new Examiners(){ Id = 1, FirstName = "FirstName1", LastName = "LastName1", MiddleName = "MiddleName1" },
               new Examiners(){ Id = 2, FirstName = "FirstName2", LastName = "LastName2", MiddleName = "MiddleName2" }
            }.AsQueryable();

            ExamSchedules = new List<ExamSchedules>()
            {
                new ExamSchedules(){ Id = 1, SessionsId = 1, GroupsId = 1, SubjectsId = 1, ExamDate = new DateTime( 2020,07, 28, 13, 03,24) },
                new ExamSchedules(){ Id = 2, SessionsId = 1, GroupsId = 1, SubjectsId = 2, ExamDate = new DateTime( 2020,06, 13, 13, 03,24) },
                new ExamSchedules(){ Id = 3, SessionsId = 1, GroupsId = 1, SubjectsId = 3, ExamDate = new DateTime( 2020,08, 23, 13, 03,24) },
                new ExamSchedules(){ Id = 4, SessionsId = 1, GroupsId = 1, SubjectsId = 4, ExamDate = new DateTime( 2020,06, 09, 13, 03,24) },
                new ExamSchedules(){ Id = 5, SessionsId = 1, GroupsId = 2, SubjectsId = 1, ExamDate = new DateTime( 2020,07, 01, 13, 03,24) },
                new ExamSchedules(){ Id = 6, SessionsId = 1, GroupsId = 2, SubjectsId = 2, ExamDate = new DateTime( 2020,05, 23, 13, 03,24) },
                new ExamSchedules(){ Id = 7, SessionsId = 1, GroupsId = 2, SubjectsId = 3, ExamDate = new DateTime( 2020,05, 22, 13, 03,24) },
                new ExamSchedules(){ Id = 8, SessionsId = 1, GroupsId = 2, SubjectsId = 4, ExamDate = new DateTime( 2020,06, 18, 13, 03,24) },
                new ExamSchedules(){ Id = 9, SessionsId = 2, GroupsId = 1, SubjectsId = 1, ExamDate = new DateTime( 2020,05, 20, 13, 03,24) },
                new ExamSchedules(){ Id = 10, SessionsId = 2, GroupsId = 1, SubjectsId = 2, ExamDate = new DateTime( 2020,07, 20, 13, 03,24) },
                new ExamSchedules(){ Id = 11, SessionsId = 2, GroupsId = 1, SubjectsId = 3, ExamDate = new DateTime( 2020,08, 14, 13, 03,24) },
                new ExamSchedules(){ Id = 12, SessionsId = 2, GroupsId = 1, SubjectsId = 4, ExamDate = new DateTime( 2020,07, 04, 13, 03,24) },
                new ExamSchedules(){ Id = 13, SessionsId = 2, GroupsId = 2, SubjectsId = 1, ExamDate = new DateTime( 2020,08, 04, 13, 03,24) },
                new ExamSchedules(){ Id = 14, SessionsId = 2, GroupsId = 2, SubjectsId = 2, ExamDate = new DateTime( 2020,05, 29, 13, 03,24) },
                new ExamSchedules(){ Id = 15, SessionsId = 2, GroupsId = 2, SubjectsId = 3, ExamDate = new DateTime( 2020,07, 30, 13, 03,24) },
                new ExamSchedules(){ Id = 16, SessionsId = 2, GroupsId = 2, SubjectsId = 4, ExamDate = new DateTime( 2020,06, 12, 13, 03,24) }
            }.AsQueryable();

            Specialties = new List<Specialties>()
            {
              new Specialties(){ Id = 1, Name = "Specialty-1", Info = "Info-1" },
              new Specialties(){ Id = 2, Name = "Specialty-2", Info = "Info-2" }
            }.AsQueryable();

            Groups = new List<Groups>()
            {
                new Groups(){ Id = 1, Name = "PM-1", SpecialtiesId = 1},
                new Groups(){ Id = 2, Name = "PM-2", SpecialtiesId = 2}
            }.AsQueryable();

            Sessions = new List<Sessions>()
            {
                new Sessions(){ Id = 1, Name = 1},
                new Sessions(){ Id = 2, Name = 2}
            }.AsQueryable();

            SessionsResults = new List<SessionsResults>()
            {
                new SessionsResults() {Id = 1, StudentsId = 1, ExamSchedulesId = 5, Value = "Offset"},
                new SessionsResults() {Id = 2, StudentsId = 1, ExamSchedulesId = 6, Value = "58"},
                new SessionsResults() {Id = 3, StudentsId = 1, ExamSchedulesId = 7, Value ="NotOffset"},
                new SessionsResults() {Id = 4, StudentsId = 1, ExamSchedulesId = 8},
                new SessionsResults() {Id = 5, StudentsId = 2, ExamSchedulesId = 1, Value ="NotOffset"},
                new SessionsResults() {Id = 6, StudentsId = 2, ExamSchedulesId = 2},
                new SessionsResults() {Id = 7, StudentsId = 2, ExamSchedulesId = 3, Value ="Offset"},
                new SessionsResults() {Id = 8, StudentsId = 2, ExamSchedulesId = 4, Value ="97"},
                new SessionsResults() {Id = 9, StudentsId = 3, ExamSchedulesId = 1, Value ="NotOffset"},
                new SessionsResults() {Id = 10, StudentsId = 3, ExamSchedulesId = 2},
                new SessionsResults() {Id = 11, StudentsId = 3, ExamSchedulesId = 3, Value ="Offset"},
                new SessionsResults() {Id = 12, StudentsId = 3, ExamSchedulesId = 4, Value ="71"},
                new SessionsResults() {Id = 13, StudentsId = 4, ExamSchedulesId = 1, Value ="NotOffset"},
                new SessionsResults() {Id = 14, StudentsId = 4, ExamSchedulesId = 2},
                new SessionsResults() {Id = 15, StudentsId = 4, ExamSchedulesId = 3, Value ="Offset"},
                new SessionsResults() {Id = 16, StudentsId = 4, ExamSchedulesId = 4, Value ="65"},
                new SessionsResults() {Id = 17, StudentsId = 5, ExamSchedulesId = 1, Value ="Offset"},
                new SessionsResults() {Id = 18, StudentsId = 5, ExamSchedulesId = 2, Value ="32"},
                new SessionsResults() {Id = 19, StudentsId = 5, ExamSchedulesId = 3, Value ="NotOffset"},
                new SessionsResults() {Id = 20, StudentsId = 5, ExamSchedulesId = 4},
                new SessionsResults() {Id = 21, StudentsId = 6, ExamSchedulesId = 5, Value ="NotOffset"},
                new SessionsResults() {Id = 22, StudentsId = 6, ExamSchedulesId = 6},
                new SessionsResults() {Id = 23, StudentsId = 6, ExamSchedulesId = 7, Value ="NotOffset"},
                new SessionsResults() {Id = 24, StudentsId = 6, ExamSchedulesId = 8},
                new SessionsResults() {Id = 25, StudentsId = 7, ExamSchedulesId = 5, Value ="Offset"},
                new SessionsResults() {Id = 26, StudentsId = 7, ExamSchedulesId = 6, Value ="16"},
                new SessionsResults() {Id = 27, StudentsId = 7, ExamSchedulesId = 7, Value ="Offset"},
                new SessionsResults() {Id = 28, StudentsId = 7, ExamSchedulesId = 8, Value ="64"},
                new SessionsResults() {Id = 29, StudentsId = 8, ExamSchedulesId = 1, Value ="NotOffset"},
                new SessionsResults() {Id = 30, StudentsId = 8, ExamSchedulesId = 2},
                new SessionsResults() {Id = 31, StudentsId = 8, ExamSchedulesId = 3, Value ="Offset"},
                new SessionsResults() {Id = 32, StudentsId = 8, ExamSchedulesId = 4, Value ="27"},
                new SessionsResults() {Id = 33, StudentsId = 9, ExamSchedulesId = 5, Value ="Offset"},
                new SessionsResults() {Id = 34, StudentsId = 9, ExamSchedulesId = 6, Value ="27"},
                new SessionsResults() {Id = 35, StudentsId = 9, ExamSchedulesId = 7, Value ="Offset"},
                new SessionsResults() {Id = 36, StudentsId = 9, ExamSchedulesId = 8, Value ="41"},
                new SessionsResults() {Id = 37, StudentsId = 10, ExamSchedulesId = 5 , Value ="Offset"},
                new SessionsResults() {Id = 38, StudentsId = 10, ExamSchedulesId = 6 , Value ="16"},
                new SessionsResults() {Id = 39, StudentsId = 10, ExamSchedulesId = 7 , Value ="NotOffset"},
                new SessionsResults() {Id = 40, StudentsId = 10, ExamSchedulesId = 8 },
                new SessionsResults() {Id = 41, StudentsId = 1 , ExamSchedulesId = 13, Value ="NotOffset"},
                new SessionsResults() {Id = 42, StudentsId = 1 , ExamSchedulesId = 14},
                new SessionsResults() {Id = 43, StudentsId = 1 , ExamSchedulesId = 15, Value ="Offset"},
                new SessionsResults() {Id = 44, StudentsId = 1 , ExamSchedulesId = 16, Value ="33"},
                new SessionsResults() {Id = 45, StudentsId = 2 , ExamSchedulesId = 9 , Value ="NotOffset"},
                new SessionsResults() {Id = 46, StudentsId = 2 , ExamSchedulesId = 10},
                new SessionsResults() {Id = 47, StudentsId = 2 , ExamSchedulesId = 11, Value ="Offset"},
                new SessionsResults() {Id = 48, StudentsId = 2 , ExamSchedulesId = 12, Value ="90"},
                new SessionsResults() {Id = 49, StudentsId = 3 , ExamSchedulesId = 9 , Value ="NotOffset"},
                new SessionsResults() {Id = 50, StudentsId = 3 , ExamSchedulesId = 10},
                new SessionsResults() {Id = 51, StudentsId = 3 , ExamSchedulesId = 11, Value ="NotOffset"},
                new SessionsResults() {Id = 52, StudentsId = 3 , ExamSchedulesId = 12},
                new SessionsResults() {Id = 53, StudentsId = 4 , ExamSchedulesId = 9 , Value ="Offset"},
                new SessionsResults() {Id = 54, StudentsId = 4 , ExamSchedulesId = 10, Value ="94"},
                new SessionsResults() {Id = 55, StudentsId = 4 , ExamSchedulesId = 11, Value ="Offset"},
                new SessionsResults() {Id = 56, StudentsId = 4 , ExamSchedulesId = 12, Value ="3"},
                new SessionsResults() {Id = 57, StudentsId = 5 , ExamSchedulesId = 9 , Value ="NotOffset"},
                new SessionsResults() {Id = 58, StudentsId = 5 , ExamSchedulesId = 10},
                new SessionsResults() {Id = 59, StudentsId = 5 , ExamSchedulesId = 11, Value ="NotOffset"},
                new SessionsResults() {Id = 60, StudentsId = 5 , ExamSchedulesId = 12},
                new SessionsResults() {Id = 61, StudentsId = 6 , ExamSchedulesId = 13, Value ="Offset"},
                new SessionsResults() {Id = 62, StudentsId = 6 , ExamSchedulesId = 14, Value ="19"},
                new SessionsResults() {Id = 63, StudentsId = 6 , ExamSchedulesId = 15, Value ="Offset"},
                new SessionsResults() {Id = 64, StudentsId = 6 , ExamSchedulesId = 16, Value ="5"},
                new SessionsResults() {Id = 65, StudentsId = 7 , ExamSchedulesId = 13, Value ="Offset"},
                new SessionsResults() {Id = 66, StudentsId = 7 , ExamSchedulesId = 14, Value ="16"},
                new SessionsResults() {Id = 67, StudentsId = 7 , ExamSchedulesId = 15, Value ="Offset"},
                new SessionsResults() {Id = 68, StudentsId = 7 , ExamSchedulesId = 16, Value ="38"},
                new SessionsResults() {Id = 69, StudentsId = 8 , ExamSchedulesId = 9 , Value ="Offset"},
                new SessionsResults() {Id = 70, StudentsId = 8 , ExamSchedulesId = 10, Value ="20"},
                new SessionsResults() {Id = 71, StudentsId = 8 , ExamSchedulesId = 11, Value ="NotOffset"},
                new SessionsResults() {Id = 72, StudentsId = 8 , ExamSchedulesId = 12},
                new SessionsResults() {Id = 73, StudentsId = 9 , ExamSchedulesId = 13, Value ="Offset"},
                new SessionsResults() {Id = 74, StudentsId = 9 , ExamSchedulesId = 14, Value ="20"},
                new SessionsResults() {Id = 75, StudentsId = 9 , ExamSchedulesId = 15, Value ="NotOffset"},
                new SessionsResults() {Id = 76, StudentsId = 9 , ExamSchedulesId = 16},
                new SessionsResults() {Id = 77, StudentsId = 10, ExamSchedulesId = 13, Value ="Offset"},
                new SessionsResults() {Id = 78, StudentsId = 10, ExamSchedulesId = 14, Value ="13"},
                new SessionsResults() {Id = 79, StudentsId = 10, ExamSchedulesId = 15, Value ="Offset"},
                new SessionsResults() {Id = 80, StudentsId = 10, ExamSchedulesId = 16, Value ="12"},
            }.AsQueryable();

            Students = new List<Students>()
            {
                new Students(){ Id = 1 , FirstName = "FirstName1" , LastName = "LastName1" , MiddleName = "Middlename1", Gender = "Female", DateOfBirthday = new DateTime(2020, 08, 23, 13, 03, 24), GroupsId = 2},
                new Students(){ Id = 2 , FirstName = "FirstName2" , LastName = "LastName2" , MiddleName = "Middlename2", Gender = "Female", DateOfBirthday = new DateTime(2020, 08, 22, 13, 03, 24), GroupsId = 1},
                new Students(){ Id = 3 , FirstName = "FirstName3" , LastName = "LastName3" , MiddleName = "Middlename3", Gender = "Female", DateOfBirthday = new DateTime(2020, 08, 21, 13, 03, 24), GroupsId = 1},
                new Students(){ Id = 4 , FirstName = "FirstName4" , LastName = "LastName4" , MiddleName = "Middlename4", Gender = "Female", DateOfBirthday = new DateTime(2020, 08, 20, 13, 03, 24), GroupsId = 1},
                new Students(){ Id = 5 , FirstName = "FirstName5" , LastName = "LastName5" , MiddleName = "Middlename5", Gender = "Male"  , DateOfBirthday = new DateTime(2020, 08, 19, 13, 03, 24), GroupsId = 1},
                new Students(){ Id = 6 , FirstName = "FirstName6" , LastName = "LastName6" , MiddleName = "Middlename6", Gender = "Male"  , DateOfBirthday = new DateTime(2020, 08, 18, 13, 03, 24), GroupsId = 2},
                new Students(){ Id = 7 , FirstName = "FirstName7" , LastName = "LastName7" , MiddleName = "Middlename7", Gender = "Female", DateOfBirthday = new DateTime(2020, 08, 17, 13, 03, 24), GroupsId = 2},
                new Students(){ Id = 8 , FirstName = "FirstName8" , LastName = "LastName8" , MiddleName = "Middlename8", Gender = "Female", DateOfBirthday = new DateTime(2020, 08, 16, 13, 03, 24), GroupsId = 1},
                new Students(){ Id = 9 , FirstName = "FirstName9" , LastName = "LastName9" , MiddleName = "Middlename9", Gender = "Female", DateOfBirthday = new DateTime(2020, 08, 15, 13, 03, 24), GroupsId = 2},
                new Students(){ Id = 10, FirstName = "FirstName10", LastName = "LastName10", MiddleName = "Middlename10",Gender = "Female", DateOfBirthday = new DateTime(2020, 08, 14, 13, 03, 24), GroupsId = 2}
            }.AsQueryable();

            Subjects = new List<Subjects>()
            {
                new Subjects(){ Id = 1, Name = "Subject-1.0", IsAssessment = "False", ExaminersId = 1},
                new Subjects(){ Id = 2, Name = "Subject-1.0", IsAssessment = "True", ExaminersId = 1},
                new Subjects(){ Id = 3, Name = "Subject-2.0", IsAssessment = "False", ExaminersId = 2},
                new Subjects(){ Id = 4, Name = "Subject-2.0", IsAssessment = "True", ExaminersId = 2}
            }.AsQueryable();

            Mock = new Mock<ITables>();
            Mock.Setup(x => x.Examiners).Returns(Examiners);
            Mock.Setup(x => x.ExamSchedules).Returns(ExamSchedules);
            Mock.Setup(x => x.Groups).Returns(Groups);
            Mock.Setup(x => x.Specialties).Returns(Specialties);
            Mock.Setup(x => x.Sessions).Returns(Sessions);
            Mock.Setup(x => x.SessionsResults).Returns(SessionsResults);
            Mock.Setup(x => x.Students).Returns(Students);
            Mock.Setup(x => x.Subjects).Returns(Subjects);

        }
    }
}
