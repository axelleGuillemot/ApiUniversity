using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ApiUniversity.Controllers;


[ApiController]
[Route("api/course")]
public class EnrollmentController : ControllerBase
{
    private readonly UniversityContext _context;


    public EnrollmentController(UniversityContext context)
    {
        _context = context;
    }


    // GET: api/course
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseDTO>>> GetEnrollment()
    {
        // Get courses and related lists
        var enrollment = _context.Enrollment.Select(x => new CourseDTO(x));
        return await enrollment.ToListAsync();
    }


    // GET: api/course/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CourseDTO>> GetEnrollement(int id)
    {
        // Find course and related list
        // SingleAsync() throws an exception if no course is found (which is possible, depending on id)
        // SingleOrDefaultAsync() is a safer choice here
        var enrollment = await _context.Course.SingleOrDefaultAsync(t => t.Id == id);


        if (course == null)
        {
            return NotFound();
        }


        return new EnrollmentDTO(enrollment);
    }


    // POST: api/course
    [HttpPost]
    public async Task<ActionResult<Course>> PostEnrollment(EnrollmentDTO enrollmentDTO)
    {
        Course course = new(EnrollmentDTO);


        _context.Enrollment.Add(enrollment);
        await _context.SaveChangesAsync();


        return CreatedAtAction(nameof(GetEnrollement), new { id = course.Id }, new EnrollmentDTO(enrollment));
    }


    // PUT: api/course/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEnrollment(int id, EnrollmentDTO enrollmentDTO)
    {
        if (id != enrollmentDTO.Id)
        {
            return BadRequest();
        }


        Enrollment enrollment = new(enrollmentDTO);


        _context.Entry(enrollment).State = EntityState.Modified;


        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Enrollment.Any(m => m.Id == id))
                return NotFound();
            else
                throw;
        }


        return NoContent();
    }


    // DELETE: api/course/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEnrollment(int id)
    {
        var enrollment = await _context.Enrollement.FindAsync(id);


        if (enrollment == null)
        {
            return NotFound();
        }


        _context.Enrollment.Remove(enrollment);
        await _context.SaveChangesAsync();


        return NoContent();
    }
}
