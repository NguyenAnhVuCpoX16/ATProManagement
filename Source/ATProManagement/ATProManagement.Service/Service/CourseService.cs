using ATProManagement.Base;
using ATProManagement.Context;
using ATProManagement.Core;
using ATProManagement.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestEase;

namespace ATProManagement.Service
{
    public class CourseService : MyServiceBase, ICourseService
    {
        public CourseService(IMyContext ctx) : base(ctx)
        {
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<Result> Delete(Guid guid)
        {
            using (var db = _ctx.ConnectDb())
            {
                try
                {
                    var item = await db.Repo<EntityCourse>().GetOne(x => x.Guid == guid);
                    if (item != null)
                    {
                        await db.Repo<EntityCourse>().Remove(item, commit: false);
                        await db.SaveChangesAsync();
                        return true;
                    }
                    return "Không tìm thấy dữ liệu";
                }
                catch (Exception ex)
                {
                    return ($"Đã có lỗi xảy ra: {ex.Message}");
                }
            }
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<PagedResultsOf<EntityCourse>> GetData([FromBody] FilterDto filter = null)
        {
            var expr = ExpressionBuilder.Build<EntityCourse>(filter?.Filters);
            return await GetData<EntityCourse>(expr);
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<ResultOf<ModelCourse>> Submit([Body] ModelCourse model)
        {
            if (!TryValidate(model, out var outputMsg))
            {
                return (outputMsg);
            }
            try
            {
                using (var db = _ctx.ConnectDb())
                {
                    var entity = await db.Repo<EntityCourse>().GetOneEdit(x => x.Guid == model.Guid);
                    if (entity == null)
                    {
                        entity = model.SetValueModel();
                        await db.Repo<EntityCourse>().Insert(entity, commit: false);
                       
                    }
                    else
                    {
                        entity.Name = model.Name;
                        entity.Description = model.Description;
                        entity.TimeModified = DateTime.Now;
                    }
                    await db.SaveChangesAsync();
                    return model;
                }
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<ResultOf<ModelClient>> GetCourse()
        {
            try
            {
                var list = new List<EntityCourse>();
                for (int i = 1; i <= 100; i++)
                {
                    list.Add(new EntityCourse
                    {
                        Guid = Guid.NewGuid(),
                        Name = $"Course {i}",
                        Description = $"Description for Course {i}",
                        TimeCreated = DateTime.Now,
                        TimeModified = DateTime.Now,
                        UserCreated = "Admin",
                        UserModified = "Admin",
                    });
                }
                using (var db = _ctx.ConnectDb())
                {
                    await db.Repo<EntityCourse>().InsertRange(list.ToArray());
                }
                return new ModelClient();
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
    }
}
