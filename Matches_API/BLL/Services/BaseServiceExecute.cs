using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Matches_API.BLL.Interfaces;
using Matches_API.BLL.Models;

namespace Matches_API.BLL.Services
{
    public class BaseServiceExecute
    {
        public static IEnumerable<ModelBase> Get(ServiceBase service) => service.Get();


        public static ModelBase Create(ServiceBase service, ModelBase model) => service.Create(model);
        public static ModelBase Delete(ServiceBase service, int id) => service.Delete(id);
        public static ModelBase Delete(ServiceBase service, ModelBase model) => service.Delete(model);
        public static ModelBase Done(ServiceBase service, ModelBase model) => ((CandidateService) service).Done(model);

    }
}