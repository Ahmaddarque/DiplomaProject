using Olympiads.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Olympiads.WEB.Helpers
{
    public static class ModelStateExt
    {
        public static IEnumerable<ErrorInfo> GetErrors(this ModelStateDictionary modelStateDict)
        {
            foreach (var key in modelStateDict.Keys)
            {
                if (modelStateDict[key].Errors.Any())
                {
                    var err = modelStateDict[key].Errors.First();
                    yield return new ErrorInfo() { Property = key, Error = err.ErrorMessage };
                }
            }
            yield break;
        }
    }
}