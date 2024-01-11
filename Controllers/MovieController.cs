using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using movies_api_pipeline_actions_azure_ci.Dtos;
using movies_api_pipeline_actions_azure_ci.Models;

namespace movies_api_pipeline_actions_azure_ci.Controllers
{
    public class MovieController : ControllerBase
    {

        private static List<Movie> movies = new List<Movie>();
        private IMapper _mapper;

        public MovieController(IMapper mapper)
        {          
            _mapper = mapper;
        }


        /// <summary>
        /// Add a new movie to the database
        /// </summary>
        /// <param name="movieDto">Object with necessary properties to create a movie</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">In the case of movie creation success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddNewMovie([FromBody] CreateMovieDto movieDto)
        {
            Movie movie = _mapper.Map<Movie>(movieDto);
            movie.Id = movies.Count + 1;
            movies.Add(movie);
            return CreatedAtAction(nameof(GetMovieById),
                new { id = movie.Id },
                movie);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = movies.FirstOrDefault(movie => movie.Id == id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }
    }
}
