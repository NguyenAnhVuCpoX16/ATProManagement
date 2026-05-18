using ATProManagement.Context;
using ATProManagement.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;


namespace ATPromanagement.Base
{
    public class MyServiceBase : IServiceBase
    {
        protected readonly IMyContext _ctx;

        private readonly ILogger<MyServiceBase> _log;

        public MyServiceBase(IMyContext ctx, ILogger<MyServiceBase> log)
        {
            _ctx = ctx;
            _log = log;
        }

        protected bool TryValidate(object model, out string outputMsg)
        {
            outputMsg = string.Empty;
            if (model == null)
            {
                outputMsg = "MODEL_IS_NULL";
                return false;
            }

            var errors = new List<string>();
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);

            if (validationResults.Count > 0)
            {
                foreach (var validationResult in validationResults)
                {
                    //ModelState.AddModelError(validationResult.MemberNames.FirstOrDefault() ?? string.Empty, validationResult.ErrorMessage);
                    errors.Add(validationResult.ErrorMessage);
                }

                outputMsg = string.Join(";", errors);
                return false;
            }

            return true;
        }


        protected async Task<PagedResultsOf<TTEntity>> GetData<TTEntity>(Expression<Func<TTEntity, bool>> baseFilter = null) where TTEntity : EntityBase
        {
            try
            {
                using (var db = _ctx.ConnectDb())
                {
                    var query = db.Repo<TTEntity>().Query();
                    if (baseFilter != null)
                    {
                        query = query.Where(baseFilter);
                    }
                    var data = await query.OrderByDescending(x=>x.TimeModified).ToListAsync();
                    return PagedResultsOf<TTEntity>.Ok(data, data.Count);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ResultsOf<OptionItem<string>>> GetCourseOptions()
        {
            try
            {
                using (var db = _ctx.ConnectDb())
                {
                    var data = await db.Repo<EntityCourse>().Query().Select(c => new OptionItem<string>(c.Guid.ToString(), c.Name)).ToListAsync();
                    return new ResultsOf<OptionItem<string>>(true, "", data);
                }
            }
            catch (Exception ex)
            {
                return new ResultsOf<OptionItem<string>>(false, ex.Message, null);
            }
        }
    }
}
