using ATPromanagement.Base;
using ATProManagement.Base;
using ATProManagement.Context;
using ATProManagement.Core;
using ATProManagement.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestEase;

namespace ATProManagement.Service
{
    public class ClientService : MyServiceBase, IClientService
    {
        public ClientService(IMyContext ctx) : base(ctx)
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
                    var item = await db.Repo<EntityClient>().GetOne(x => x.Guid == guid);
                    if (item != null)
                    {
                        await db.Repo<EntityClient>().Remove(item, commit: false);
                        await db.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        return "Không tìm thấy client với Guid đã cho.";
                    }
                    
                }
                catch (Exception ex)
                {
                    return ($"Đã có lỗi xảy ra: {ex.Message}");
                }
            }
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<PagedResultsOf<EntityClient>> GetData([FromBody] FilterDto filter = null)
        {
            var expr = ExpressionBuilder.Build<EntityClient>(filter?.Filters);
            return await GetData<EntityClient>(expr);
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<ResultOf<ModelClient>> Submit([Body] ModelClient model)
        {
            if (!TryValidate(model, out var outputMsg))
            {
                return (outputMsg);
            }
            try
            {
                using (var db = _ctx.ConnectDb())
                {
                    var entity = await db.Repo<EntityClient>().GetOneEdit(x => x.Guid == model.Guid);
                    if (entity == null)
                    {
                        entity = model.SetValueModel();
                        await db.Repo<EntityClient>().Insert(entity, commit: false);
                    }
                    else
                    {
                        entity.Name = model.Name;
                        entity.Email = model.Email;
                        entity.Phone = model.Phone;
                        entity.Message = model.Message;
                        entity.CourseName = model.CourseName;
                        entity.GuidCourse = model.GuidCourse;
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
        public async Task<Result> RemoveRange(List<EntityClient> list)
        {
            try
            {
                using (var db = _ctx.ConnectDb())
                {
                    await db.Repo<EntityClient>().RemoveRange(list.ToArray());
                    await db.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<ResultOf<ModelClient>> GetClient()
        {
            try
            {
                var rd = new Random();
                using (var db = _ctx.ConnectDb())
                {
                    var courses = await db.Repo<EntityCourse>().GetList();
                    var list = new List<EntityClient>();
                    for (int i = 1; i <= 100; i++)
                    {
                        var course = courses[rd.Next(0, courses.Count)];
                        list.Add(new EntityClient
                        {
                            Guid = Guid.NewGuid(),
                            Name = $"Client {i}",
                            Email = $"client{i}@example.com",
                            Phone = $"123-456-789{i}",
                            TimeCreated = DateTime.Now,
                            TimeModified = DateTime.Now,
                            UserCreated = "Admin",
                            UserModified = "Admin",
                            CourseName = course.Name,
                            GuidCourse = course.Guid,
                        });
                    }
                    await db.Repo<EntityClient>().InsertRange(list.ToArray());
                }
                return new ModelClient();
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ResultsOf<OptionItem<string>>> GetCourseOptions()
        {
            return await base.GetCourseOptions();
        }
    }
}
