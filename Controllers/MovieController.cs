using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using movies_api_pipeline_actions_azure_ci.Dtos;
using movies_api_pipeline_actions_azure_ci.Models;

namespace movies_api_pipeline_actions_azure_ci.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger _logger;
        private static List<Movie> movies = new List<Movie>();
        private IMapper _mapper;

        public MovieController(IMapper mapper, ILogger<MovieController> logger)
        {          
            _mapper = mapper;
            _logger = logger;
        }


        /// <summary>
        /// Register a new movie
        /// </summary>
        /// <param name="movieDto">Object with necessary properties to create a movie</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">In the case of movie creation success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Movie), 201)]
        public IActionResult AddNewMovie([FromBody] CreateMovieDto movieDto)
        {
            _logger.LogInformation("Post request to AddNewMovie received");
            Movie movie = _mapper.Map<Movie>(movieDto);
            movie.Id = movies.Count + 1;
            movies.Add(movie);
            return CreatedAtAction(nameof(GetMovieById),
                new { id = movie.Id },
                movie);
        }

        /// <summary>
        /// Given an ID returns a movie
        /// </summary>
        /// <param name="id">Existing movie ID</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">In case of movie found</response>
        /// <response code="404">Movie not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Movie), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetMovieById(int id)
        {
            _logger.LogInformation("Get request to Movie by ID received with {id}");
            var movie = movies.FirstOrDefault(movie => movie.Id == id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        /// <summary>
        /// Return all movies registered
        /// </summary>      
        /// <returns>IActionResult</returns>
        /// <response code="200">In case of any movie registered</response>
        /// <response code="404">Movie not found</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Movie>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetMovies()
        {
            _logger.LogInformation("Get request to all Movies received");
            if (movies.Count > 0)
                return Ok(movies);
            
            return NotFound();
            
        }
    }
}
