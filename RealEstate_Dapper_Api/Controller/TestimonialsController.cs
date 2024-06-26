using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.TestimonialRepositories;

namespace RealEstate_Dapper_Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public TestimonialsController(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var values = await _testimonialRepository.GetAllTestimonial();
            return Ok(values);
        }
    }
}
