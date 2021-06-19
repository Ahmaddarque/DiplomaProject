using OlympiadUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OlympiadUI.Repository
{
    public static class TestsRepository
    {
        public static Test GetById(this IQueryable<Test> tests, int id)
        {
            return tests.FirstOrDefault(x => x.Id == id);
        }
        public static bool ExistsWithId (this IQueryable<Test> tests,int id)
        {
            bool exists = false;
            if (tests.Where(x => x.Id == id).Count() > 0)
            {
                exists = true;
            }

            return exists;
        }
        public static IQueryable<Test> FilterByName(this IQueryable<Test> tests, string name) 
        {
            IQueryable<Test> filteredTests = tests;
            if (!string.IsNullOrEmpty(name))
                filteredTests = filteredTests.Where(x => x.Name.Contains(name));

            return filteredTests;
        } 
        public static IQueryable<Test> FilterByCategory(this IQueryable<Test> tests, int CategoryId) => tests.Where(x => x.ParticipantCategoryId == CategoryId);
        public static IQueryable<Test> FilterBySubject(this IQueryable<Test> tests, int SubjectId)
        {
            return tests.Where(x => x.KnowledgeFields.Any(x => x.SubjectId == SubjectId));
        }
        public static IQueryable<Test> FilterBySubjects(this IQueryable<Test> tests, int[] SubjectIds)
        {
            return tests.Where(x => x.KnowledgeFields.Any(x => SubjectIds.Contains(x.SubjectId.Value)));
        }
        public static IQueryable<Test> FilterByCategories(this IQueryable<Test> tests, int[] CategoryIds)
        {
            return tests.Where(x => CategoryIds.Contains(x.ParticipantCategoryId));
        }
    }
}