
using ATPromanagement.Abstract;
using ATProManagement.Context;
using ATProManagement.Core;
using ATProManagement.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ATProManagement.Controller
{
    [ApiAuthorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CourseController : CourseService, ICourseService
    {
        public CourseController(IMyContext ctx) : base(ctx)
        {
        }
    }
}
